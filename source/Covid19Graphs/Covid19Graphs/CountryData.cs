using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Graphs {
    static class CountryData {

        public async static Task<DailyCases[]> PullConfirmedData(string countrySlug) {

            //sets up the url for the passed coutry
            string url = $"https://api.covid19api.com/total/dayone/country/{ countrySlug }/status/confirmed";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url)) {

                //checks if the url request was successful
                if (response.IsSuccessStatusCode) {

                    //turns the url response json data into an array of cases objects
                    DailyCases[] allConfirmed = await response.Content.ReadAsAsync<DailyCases[]>();

                    //returns the object
                    return allConfirmed;

                } else {

                    //lets the user know why the request failed
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
