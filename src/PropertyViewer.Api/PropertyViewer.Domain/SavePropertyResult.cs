namespace PropertyViewer.Domain
{
    public abstract class SavePropertyResult
    {
        public bool Success { get; }

        public string? ErrorMessage { get; }

        protected SavePropertyResult(bool success, string? errorMessage = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }

    public class SuccessSavePropertyResult : SavePropertyResult
    {
        public SuccessSavePropertyResult()
            : base(true) { }
    }

    public class IdNotFoundResult : SavePropertyResult
    {
        public IdNotFoundResult(int id)
            : base(false, $"Property with id: {id} not found") { }
    }

    public class AlreadySavedResult : SavePropertyResult
    {
        public AlreadySavedResult(int id)
            : base(false, $"Property with id: {id} was already saved") { }
    }
}