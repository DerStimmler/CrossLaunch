using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CrossLaunch.Utils;
using Serilog;

namespace CrossLaunch.Features.Epic;

public class EgDataService
{
  private readonly HttpClient _http;

  public EgDataService()
  {
    _http = new HttpClient { BaseAddress = new Uri("https://api.egdata.app") };
  }

  public async Task<EgDataItem?> FindGame(string @namespace, string gameId)
  {
    try
    {
      var response = await _http.GetAsync($"/sandboxes/{@namespace}/items");

      if (!response.IsSuccessStatusCode)
        return null;

      var items = await response.Content.ReadFromJsonAsync<List<EgDataItem>>(
        CustomJsonSerializerContext.Default.ListEgDataItem
      );

      return items?.FirstOrDefault(item => item.Id == gameId);
    }
    catch (Exception e)
    {
      Log.Error(e, "Couldn't load epic game {Namespace}, {GameId} from egdata", @namespace, gameId);
      return null;
    }
  }
}
