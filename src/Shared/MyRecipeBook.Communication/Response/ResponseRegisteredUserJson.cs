namespace MyRecipeBook.Communication.Response;
public class ResponseRegisteredUserJson
{
    public string Name { get; set; } = string.Empty;

    public ResponseTokensJson TokensJson { get; set; } = new ResponseTokensJson();
}
