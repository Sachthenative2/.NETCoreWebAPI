using Microsoft.AspNetCore.Mvc;
using static WEB_API.DBManager;
namespace WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
       // private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       // private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            //_logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet(Name = "GetData")]
        public List<Temp> GetDataFromTable()
        {
            List<Temp> lTemp = new List<Temp>();
            DBManager db = new DBManager();
            lTemp = db.GetData();
            return lTemp;
        }
        [HttpPost(Name = "PostData")]
        public bool PostData(Temp temp)
        {
            bool success = false;
            DBManager db = new DBManager();
            try
            {
                success = db.SaveData(temp);
            }
            catch (Exception ex)
            {
                //_logger.Error(ex);
            }
            return success;
        }
        [HttpPost(Name = "RemoveData")]
        public bool RemoveData(string val)
        {
            bool success = false;
            DBManager db = new DBManager();
            try
            {
                success = db.RemoveData(val);
            }
            catch (Exception ex)
            {
                //_logger.Error(ex);
            }
            return success;
        }
        [HttpPost(Name = "UpdateData")]
        public bool UpdateData(string val1, string val2)
        {
            bool success = false;
            DBManager db = new DBManager();
            try
            {
                success = db.UpdateData(val1, val2);
            }
            catch (Exception ex)
            {
                //_logger.Error(ex);
            }
            return success;
        }
    }
}