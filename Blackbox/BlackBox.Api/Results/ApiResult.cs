using Microsoft.AspNetCore.Mvc;

namespace BlackBox.Api.Results
{
    public class ApiResult
    {
        public static async Task<ActionResult> ResponseAsync(Func<Task<object>> expression)
        {
            try 
            {
                var result = await expression.Invoke();
                return new ObjectResult(result);
            }
            catch (Exception ex) 
            {
                return new NotFoundResult();
            }
        }
    }
}
