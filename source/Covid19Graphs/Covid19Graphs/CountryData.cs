using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Graphs {
    static class CountryData {

        public async static Task<Confirmed> PullConfirmedData(string countrySlug) {

            //sets up the url for the passed coutry
            string url = $"https://api.covid19api.com/dayone/country/{ countrySlug }/status/confirmed";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url)) {

                //checks if the url request was successful
                if (response.IsSuccessStatusCode) {

                    //turns the url response data into an object
                    Confirmed confirmed = await response.Content.ReadAsAsync<Confirmed>();

                    //returns the object
                    return confirmed;

                } else {

                    //lets the user know why the request failed
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
