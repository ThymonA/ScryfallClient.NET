using System.Collections.Generic;

namespace ScryfallAPI
{
    public class SetsClient : ApiClient, ISetsClient
    {
        public SetsClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        public Set Get(long id)
        {
            id.ArgumentNotNull(nameof(id));

            return ApiConnection.Get<Set>(ApiUrls.Set(id)).Result;
        }

        public Set Get(string code)
        {
            code.ArgumentNotNull(nameof(code));

            return ApiConnection.Get<Set>(ApiUrls.Set(code)).Result;
        }

        public IReadOnlyList<Set> GetAll => ApiConnection.Get<Sets>(ApiUrls.Sets()).Result.Data;
    }
}
