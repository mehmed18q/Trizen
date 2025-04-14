USE [TrizenDB]
GO
/****** Object:  StoredProcedure [dbo].[GetSuggestedTours]    Script Date: 4/14/2025 8:50:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sadeq Kiumarsi>
-- Create date: <2025-04-10>
-- Description:	<Get Suggested Tours>
-- =============================================
ALTER PROCEDURE [dbo].[GetSuggestedTours]
    -- Add the parameters for the stored procedure here
    @userId INT
AS
BEGIN

    DECLARE @UserPersonalityId INT,
            @UserAge INT,
			@UserGender INT,
			@BatchId NVARCHAR(40) = NEWID();

    BEGIN --region The User Information
        SELECT @UserPersonalityId = u.PersonalityId,
               @UserAge = DATEDIFF(YEAR, u.BirthDay, GETDATE()),
			   @UserGender = u.Gender
        FROM dbo.Users u
        WHERE u.Id = @userId;
    END; --endregion

    BEGIN --region The User Travels
        SELECT TourId = t.Id,
               Score = (tr.Status + 1) * 2,
               t.DestinationId,
               d.DestinationTypeId
        INTO #TraveldTours
        FROM dbo.Users u
            LEFT JOIN dbo.Passengers p
                ON p.PassengerUserId = u.Id
            LEFT JOIN dbo.Travels tr
                ON tr.Id = p.TravelId
            LEFT JOIN dbo.Tours t
                ON t.Id = tr.TraveledTourId
            LEFT JOIN dbo.Destinations d
                ON t.DestinationId = d.Id
        WHERE u.Id = @userId;
    END; --endregion

    BEGIN --region The User #Observation
		SELECT	ObservedTourId,
				Score,
				DestinationId,
				DestinationTypeId,
				ObserveType
			INTO #ObservedTours
		FROM
		(SELECT	UserId = u.id,
				ot.ObservedTourId,
				Score = (ot.ObserveType + 1) * 2,
				t.DestinationId,
				d.DestinationTypeId,
				ot.ObserveType
        FROM dbo.Users u
            LEFT JOIN dbo.TourObserves ot
                ON ot.ObserverUserId = u.Id
            LEFT JOIN dbo.Tours t
                ON t.Id = ot.ObservedTourId
            LEFT JOIN dbo.Destinations d
                ON t.DestinationId = d.Id
		UNION
        SELECT	UserId = u.id,
				ObservedTourId = t.Id,
				Score = (do.ObserveType + 1) * 2,
				t.DestinationId,
				d.DestinationTypeId,
				do.ObserveType
        FROM dbo.Users u
            LEFT JOIN dbo.DestinationObserves do
                ON do.ObserverUserId = u.Id
            LEFT JOIN dbo.Destinations d
                ON d.Id = do.ObservedDestinationId
            LEFT JOIN dbo.Tours t
                ON t.DestinationId = d.Id) f
        WHERE f.UserId = @userId;
    END; --endregion

    BEGIN --region Preparation User Data
        SELECT tours.TourId,
               Score = SUM(tours.Score)
        INTO #Tours
        FROM
        (
            -- Tours based on Personality Tour Type
            SELECT TourId = t.Id,
                   Score = 4,
                   BasedOn = 'Tours based on Personality Tour Type'
            FROM dbo.Users u
                LEFT JOIN dbo.PersonalityTourTypes ptt
                    ON ptt.PersonalityId = u.PersonalityId
                LEFT JOIN dbo.Tours t
                    ON t.TourTypeId = ptt.TourTypeId
            WHERE u.Id = @userId
            UNION ALL

            -- Tours based on Personality Destination Type
            SELECT t.Id,
                   Score = 4,
                   'Tours based on Personality Destination Type'
            FROM dbo.Users u
                LEFT JOIN dbo.PersonalityDestinationTypes pdt
                    ON pdt.PersonalityId = u.PersonalityId
                LEFT JOIN dbo.Destinations d
                    ON d.DestinationTypeId = pdt.DestinationTypeId
                LEFT JOIN dbo.Tours t
                    ON t.DestinationId = d.Id
            WHERE u.Id = @userId
            UNION ALL

            -- Tours based on Personality Tour Category
            SELECT t.Id,
                   Score = 4,
                   'Tours based on Personality Tour Category'
            FROM dbo.Users u
                LEFT JOIN dbo.PersonalityCategories pc
                    ON pc.PersonalityId = u.PersonalityId
                LEFT JOIN dbo.TourCategories tc
                    ON tc.CategoryId = pc.CategoryId
                LEFT JOIN dbo.Tours t
                    ON t.Id = tc.TourId
            WHERE u.Id = @userId
            UNION ALL

            -- Tours based on Personality Destination Category
            SELECT t.Id,
                   Score = 4,
                   'Tours based on Personality Destination Category'
            FROM dbo.Users u
                LEFT JOIN dbo.PersonalityCategories pc
                    ON pc.PersonalityId = u.PersonalityId
                LEFT JOIN dbo.DestinationCategories dc
                    ON dc.CategoryId = pc.CategoryId
                LEFT JOIN dbo.Tours t
                    ON t.DestinationId = dc.DestinationId
            WHERE u.Id = @userId
            UNION ALL

            -- Tours based on User Travels
            SELECT TourId,
                   Score,
                   'Tours based on User Travels'
            FROM #TraveldTours
            UNION ALL

            -- Tours based on User Visit Observe
            SELECT ObservedTourId,
                   Score,
                   'Tours based on User Visit Observe'
            FROM #ObservedTours
            WHERE ObserveType = 0
            UNION ALL

            -- Tours based on User Like Observe
            SELECT ObservedTourId,
                   Score + 2,
                   'Tours based on User Like Observe'
            FROM #ObservedTours
            WHERE ObserveType = 1
            UNION ALL

            -- Tours based on User Travels Tour Category
            SELECT tc.TourId,
                   Score = 3,
                   'Tours based on User Travels Tour Category'
            FROM dbo.TourCategories tc
            WHERE tc.CategoryId IN
                  (
                      SELECT ttc.CategoryId
                      FROM dbo.TourCategories ttc
                      WHERE ttc.TourId IN
                            (
                                SELECT tt.TourId FROM #TraveldTours tt
                            )
                  )
            UNION ALL

            -- Tours based on User Travels Destination Category
            SELECT tc.TourId,
                   Score = 3,
                   'Tours based on User Travels Destination Category'
            FROM dbo.TourCategories tc
            WHERE tc.CategoryId IN
                  (
                      SELECT dc.CategoryId
                      FROM dbo.DestinationCategories dc
                      WHERE dc.DestinationId IN
                            (
                                SELECT tdc.DestinationId
                                FROM dbo.DestinationCategories tdc
                                WHERE tdc.DestinationId IN
                                      (
                                          SELECT tt.DestinationId FROM #TraveldTours tt
                                      )
                            )
                  )
            UNION ALL

            -- Tours based on User Travels Tour Type
            SELECT t.Id,
                   Score = 3,
                   'Tours based on User Travels Tour Type'
            FROM dbo.Tours t
            WHERE t.TourTypeId IN
                  (
                      SELECT tt.TourId FROM #TraveldTours tt
                  )
            UNION ALL

            -- Tours based on User Travels Destination Type
            SELECT t.Id,
                   Score = 3,
                   'Tours based on User Travels Destination Type'
            FROM dbo.Tours t
                LEFT JOIN dbo.Destinations d
                    ON d.Id = t.DestinationId
            WHERE d.DestinationTypeId IN
                  (
                      SELECT tt.DestinationTypeId FROM #TraveldTours tt
                  )
            UNION ALL

            -- Tours based on User Observation Tour Category
            SELECT tc.TourId,
                   Score = 2,
                   'Tours based on User Observation Tour Category'
            FROM dbo.TourCategories tc
            WHERE tc.CategoryId IN
                  (
                      SELECT ttc.CategoryId
                      FROM dbo.TourCategories ttc
                      WHERE ttc.TourId IN
                            (
                                SELECT ot.ObservedTourId FROM #ObservedTours ot
                            )
                  )
            UNION ALL

            -- Tours based on User Observation Destination Category
            SELECT tc.TourId,
                   Score = 2,
                   'Tours based on User Observation Destination Category'
            FROM dbo.TourCategories tc
            WHERE tc.CategoryId IN
                  (
                      SELECT dc.CategoryId
                      FROM dbo.DestinationCategories dc
                      WHERE dc.DestinationId IN
                            (
                                SELECT tdc.DestinationId
                                FROM dbo.DestinationCategories tdc
                                WHERE tdc.DestinationId IN
                                      (
                                          SELECT ot.DestinationId FROM #ObservedTours ot
                                      )
                            )
                  )
            UNION ALL

            -- Tours based on User Observation Tour Type
            SELECT t.Id,
                   Score = 2,
                   'Tours based on User Observation Tour Type'
            FROM dbo.Tours t
            WHERE t.TourTypeId IN
                  (
                      SELECT ot.ObservedTourId FROM #ObservedTours ot
                  )
            UNION ALL

            -- Tours based on User Observation Destination Type
            SELECT t.Id,
                   Score = 2,
                   'Tours based on User Observation Destination Type'
            FROM dbo.Tours t
                LEFT JOIN dbo.Destinations d
                    ON d.Id = t.DestinationId
            WHERE d.DestinationTypeId IN
                  (
                      SELECT ot.DestinationTypeId FROM #ObservedTours ot
                  )
        ) tours
		LEFT JOIN dbo.Tours t	ON tours.TourId = t.Id
        WHERE tours.TourId IS NOT NULL
		AND t.StartTime > GETDATE()
        GROUP BY tours.TourId;
    END; --endregion

    BEGIN --region Select User Data
        SELECT TourId = t.TourId,
               Score = COALESCE(t.Score, 0)
        FROM #Tours t
        WHERE t.TourId IS NOT NULL
              AND COALESCE(t.Score, 0) > 0;
    END; --endregion


    BEGIN --region Insert User Data
        INSERT INTO dbo.SuggestedTours
        (
			BatchId,
            UserId,
            PersonalityId,
            UserAge,
			Gender,
            SuggestTime,
            TourId,
            Score
        )
        SELECT	@BatchId,
				@userId,
				@UserPersonalityId,
				@UserAge,
				@UserGender,
				GETDATE(),
				t.TourId,
				COALESCE(t.Score, 0)
        FROM #Tours t
        WHERE t.TourId IS NOT NULL
              AND COALESCE(t.Score, 0) > 0;
    END; --endregion

    BEGIN --region Drop Tables
        DROP TABLE #TraveldTours;
        DROP TABLE #ObservedTours;
        DROP TABLE #Tours;
    END; --endregion
END;
