namespace TaskBoardApp.Common
{
    using System.IO.Pipes;
    using static EntityValidationConstants.TaskValidationConstants;
    public static class EntityValidationErrorMessages
    {
       public const string TitleIncorrectLength = "Title length must be between {2} and {1}!";
       public const string DescriptionIncorrectLength = "Description length must be between {2} and {1}!";
    }
}
