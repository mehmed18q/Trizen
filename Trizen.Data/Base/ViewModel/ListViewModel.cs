namespace Trizen.Data.Base.ViewModel;

public record ListViewModel
{
    public int Id { get; set; }
    public bool IsSelected { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}

public record ErrorViewModel
{
    public int ErrorCode { get; set; }
    public string? Title { get; set; }
    public string? ErrorMessage { get; set; }
}