namespace MyRecipeBook.Communication.Response;
public class ResponseErrorJson
{
    public List<string> Errors { get; private set; }

    public ResponseErrorJson(List<string> errorMessage) => Errors = errorMessage;

    public ResponseErrorJson(string errorMessage) => Errors = [errorMessage];

}
