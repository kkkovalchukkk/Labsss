using Microsoft.AspNetCore.Mvc;
using System;

namespace YourAppName.Controllers
{
    [Route("api/[controller]")] // аттрибут определяющий маршрут к контроллеру ("/api/test")
    [ApiController]
    public class TestController : ControllerBase // создаю класс testController, который наследуюается от ControllerBase
    {
        [HttpGet("{count}")] // обработка гет-запроса, принимает каунт 
        public IActionResult Get(int count)
        {
            //генерим массив с помощью цикла и Random()
            Random random = new Random();
            int[] numbers = new int[count];

            for (int i = 0; i < count; i++)
            {
                numbers[i] = random.Next();
            }
            //возвращаем массив
            return Ok(numbers);
        }
    }
}
