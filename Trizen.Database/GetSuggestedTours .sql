-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetSuggestedTours 
	-- Add the parameters for the stored procedure here
	@userId INT
AS
BEGIN
	
DECLARE @UserPersonalityId INT,
		@UserAge INT;

-- The User Information
SELECT	@UserPersonalityId = u.PersonalityId, 
		@UserAge = DATEDIFF(YEAR, u.BirthDay, GETDATE())
FROM Users u
WHERE u.Id = @userId

BEGIN--region User

-- #ThisUserDestinationTypes -> Personality Destination Types
SELECT pdt.DestinationTypeId
	INTO #ThisUserDestinationTypes
FROM PersonalityDestinationTypes pdt
WHERE pdt.PersonalityId = @UserPersonalityId;

-- #ThisUserTourTypes -> Personality Tour Types
SELECT ptt.TourTypeId
	INTO #ThisUserTourTypes
FROM PersonalityTourTypes ptt
WHERE ptt.PersonalityId = @UserPersonalityId;

-- #ThisUserCategories -> Personality Categories
SELECT pc.CategoryId
	INTO #ThisUserCategories
FROM PersonalityCategories pc
WHERE pc.PersonalityId = @UserPersonalityId;

END --endregion

BEGIN--region Travel
SELECT DISTINCT t.TraveledTourId
	INTO #TraveledTourId
FROM Travels t
LEFT JOIN Passengers p	ON t.Id = p.TravelId
WHERE (t.UserId = @userId
OR p.PassengerUserId = @userId)

SELECT	t.TourTypeId, 
		d.DestinationTypeId,
		TourId = t.Id,
		t.DestinationId
	INTO #TraveledTours
FROM Tours t
LEFT JOIN Destinations d	on t.DestinationId = d.Id
WHERE t.Id IN (SELECT * FROM #TraveledTourId)

SELECT	tc.CategoryId 
	INTO #TraveledTourCategories
FROM Tours t
LEFT JOIN TourCategories tc	on t.id = tc.TourId
WHERE t.Id IN (SELECT * FROM #TraveledTourId)
END --endregion

BEGIN--region Tour Observe
SELECT	ObservedTourId,
		Score = SUM(ScoreCount)
	INTO #UserTourObserves
FROM (
SELECT	[to].ObservedTourId,
		ScoreCount = COUNT(*)
FROM TourObserves [to]
WHERE [to].ObserveType = 0
AND [to].ObserverUserId = @userId
GROUP BY [to].ObservedTourId
UNION ALL
SELECT	[to].ObservedTourId,
		ScoreCount = 2
FROM TourObserves [to]
WHERE [to].ObserveType = 1
AND [to].ObserverUserId = @userId
GROUP BY [to].ObservedTourId) frm
GROUP BY ObservedTourId
END --endregion

SELECT	Id,
		Score = SUM(Score)
FROM(
SELECT	t.Id,
		Score = (CASE WHEN tc.CategoryId IN (SELECT tuc.CategoryId FROM #ThisUserCategories tuc) THEN 4 ELSE 0 END) + 
				(CASE WHEN t.TourTypeId IN (SELECT tutt.TourTypeId FROM #ThisUserTourTypes tutt) THEN 4 ELSE 0 END) +
				(CASE WHEN d.DestinationTypeId IN (SELECT tudt.DestinationTypeId FROM #ThisUserDestinationTypes tudt) THEN 4 ELSE 0 END) +

				(CASE WHEN tc.CategoryId IN (SELECT ttc.CategoryId FROM #TraveledTourCategories ttc) THEN 3 ELSE 0 END) + 
				(CASE WHEN t.TourTypeId IN (SELECT tt.TourTypeId FROM #TraveledTours tt) THEN 3 ELSE 0 END) +
				(CASE WHEN d.DestinationTypeId IN (SELECT tt.DestinationTypeId FROM #TraveledTours tt) THEN 3 ELSE 0 END) +
				COALESCE((SELECT TOP(1) uto.Score FROM #UserTourObserves uto WHERE uto.ObservedTourId = t.Id), 0)
FROM Tours t
LEFT JOIN TourCategories tc	ON tc.TourId = t.Id
LEFT JOIN Destinations d	ON d.Id = t.DestinationId
WHERE (@UserAge >= t.MinimumAge
AND @UserAge <= t.MaximumAge)
AND t.Id NOT IN (SELECT tt.TourId FROM #TraveledTours tt)
AND t.DestinationId NOT IN (SELECT tt.DestinationId FROM #TraveledTours tt)) frm
GROUP BY Id
ORDER BY Score DESC
OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;

DROP TABLE #ThisUserCategories
DROP TABLE #ThisUserDestinationTypes
DROP TABLE #ThisUserTourTypes

DROP TABLE #TraveledTourId
DROP TABLE #TraveledTours
DROP TABLE #TraveledTourCategories

DROP TABLE #UserTourObserves
END
GO
