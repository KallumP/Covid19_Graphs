using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Covid19Graphs {
    static class DataPuller {

        static public HttpClient ApiClient { get; set; }


        static public void InitializeClient() {

            ApiClient = new HttpClient();

            ApiClient.DefaultRequestHeaders.Accept.Clear();

            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        /// <summary>
        /// Pulls all data about the passed in country
        /// </summary>
        /// <param name="countrySlug">The slug of the country to be pulled</param>
        /// <returns></returns>
        public async static Task<CasesObj[]> PullConfirmedData(string countrySlug) {

            //sets up the url for the passed coutry
            string url = $"https://api.covid19api.com/total/dayone/country/{ countrySlug }/status/confirmed";

            using (HttpResponseMessage response = await DataPuller.ApiClient.GetAsync(url)) {

                //checks if the url request was successful
                if (response.IsSuccessStatusCode) {

                    //turns the url response json data into an array of cases objects
                    CasesObj[] allConfirmed = await response.Content.ReadAsAsync<CasesObj[]>();

                    //returns the object
                    return allConfirmed;

                } else {

                    //lets the user know why the request failed
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async static Task<CountryObj[]> PullAllCountries() {


            //sets up the url for the passed coutry
            string url = $"https://api.covid19api.com/countries";

            using (HttpResponseMessage response = await DataPuller.ApiClient.GetAsync(url)) {

                //checks if the url request was successful
                if (response.IsSuccessStatusCode) {

                    //turns the url response json data into an array of cases objects
                    CountryObj[] allCountries = await response.Content.ReadAsAsync<CountryObj[]>();

                    //returns the object
                    return allCountries;

                } else {

                    //lets the user know why the request failed
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
