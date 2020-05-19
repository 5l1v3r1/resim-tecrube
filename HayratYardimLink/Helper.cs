using System.Net.Http;
using System.Threading.Tasks;

namespace HayratYardimLink
{
    public static class Helper
    {
        public static async Task<string> KisaLinkiGetir(string link)
        {
            var url = $"https://kisalt.hayrat.dev/?link={link}";

            using (var client = new HttpClient())
            using (var response = client.GetAsync(url).Result)
            using (var content = response.Content)
            {
                var x = await content.ReadAsStringAsync();
                return x;
            }
        }
    }
}