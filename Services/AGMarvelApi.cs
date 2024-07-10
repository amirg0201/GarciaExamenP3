using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarciaExamenP3.Models;
using Refit;

namespace GarciaExamenP3.Services
{
    public interface AGMarvelApi
    {
        [Get("/v1/public/characters")]
        Task<AGMarvelResponse> GetCharactersAsync(
            [AliasAs("apikey")] string apiKey,
            [AliasAs("hash")] string hash,
            [AliasAs("ts")] string timestamp);
    }
}
