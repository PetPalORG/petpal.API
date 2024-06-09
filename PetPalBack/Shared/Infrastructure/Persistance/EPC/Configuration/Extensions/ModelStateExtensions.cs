using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace cat_up_api.Shared.Infrastructure.Persistence.EPC.Configuration.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessage(this ModelStateDictionary dictionary)
        {
            return dictionary
                .SelectMany(m => m.Value!.Errors)
                .Select(m => m.ErrorMessage)
                .ToList();
        }
    }
}
