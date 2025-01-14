using DataModels.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperimentalController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from ExperimentalController");
        }

        [HttpGet("Opgave 1")]
        public int OpgaveEt()
        {
            int opgaveEt = 5;
            return opgaveEt;
        }

        [HttpGet("Opgave 2")]
        public string OpgaveTo()
        {
            string opgaveTo = "jeg er god";
            return opgaveTo;
        }

        [HttpGet("Opgave 3")]
        public int[] OpgaveTre()
        {
            int[] opgaveTre = { 3, 6, 9 };
            return opgaveTre;
        }

        [HttpGet("Opgave 4")]
        public int[] OpgaveFire()
        {
            int[] opgaveFireArray = new int[10];

            for (int opgaveFire = 0; opgaveFire < 10; opgaveFire++)
            {
                opgaveFireArray[opgaveFire] = opgaveFire + 1;
            }

            return opgaveFireArray;
        }

        [HttpGet("Opgave 4.5")]
        public int[] OpgaveFireKommaFem()
        {
            var opgaveFireList = new List<int>();

            for (int opgaveFire = 1; opgaveFire < 11; opgaveFire++)
            {
                opgaveFireList.Add(opgaveFire);
                Console.WriteLine(opgaveFire);
            }

            return opgaveFireList.ToArray();
        }

        [HttpGet("Opgave 5")]
        public int[] OpgaveFem()
        {
            int[] opgaveFemArray = new int[10];

            for (int opgaveFem = 0; opgaveFem < 10; opgaveFem++)
            {
                opgaveFemArray[opgaveFem] = 10 - opgaveFem;
            }

            return opgaveFemArray;
        }

        [HttpGet("Opgave 5.5")]
        public int[] OpgaveFemKommaFem()
        {
            var opgaveFemList = new List<int>();

            for (int opgaveFem = 11; opgaveFem > 0; opgaveFem--)
            {
                opgaveFemList.Add(opgaveFem);
                Console.Write(opgaveFem);
            }

            return opgaveFemList.ToArray();
        }

        [HttpGet("Opgave 6")]
        public string[] OpgaveSeks()
        {
            string[] opgaveSeks = { "Bo", "Bodil", "Erik" };
            return opgaveSeks;
        }

        [HttpGet("Opgave 7")]
        public int[] OpgaveSyv()
        {
            int[] opgaveSyv = { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            return opgaveSyv;
        }

        [HttpGet("Opgave 7.5")]
        public int[] OpgaveSyvKommaFem()
        {
            int[] opgaveSyvArray = new int[10];
            for (int opgaveSyv = 0;  opgaveSyv < 10; opgaveSyv++)
            {
                opgaveSyvArray[opgaveSyv] = opgaveSyv + 21;
            }

            return opgaveSyvArray;
        }

        [HttpGet("Opgave 7.5.2")]
        public int[] OpgaveSyvKommaFemTo()
        {
            int[] opgaveSyvArray = new int[10];
            for (int opgaveSyv = 20; opgaveSyv < 30; opgaveSyv++)
            {
                opgaveSyvArray[opgaveSyv - 20] = opgaveSyv;
            }

            return opgaveSyvArray;
        }

        [HttpGet("Opgave 8")]
        public int[] OpgaveOtte()
        {
            int[] opgaveOtte = { 40, 41, 42, 43, 44, 45 };
            return opgaveOtte;
        }

        [HttpGet("Opgave 8.5")]
        public int[] OpgaveOtteKommaFem()
        {
            int[] opgaveOtteArray = new int[6];
            for (int opgaveOtte = 0; opgaveOtte < 6; opgaveOtte++)
            {
                opgaveOtteArray[opgaveOtte] = opgaveOtte + 40;
            }

            return opgaveOtteArray;
        }

        [HttpGet("Opgave 8.5.2")]
        public int[] OpgaveOtteKommaFemTo()
        {
            int[] opgaveOtteArray = new int[6];
            for (int opgaveOtte = 40; opgaveOtte < 46; opgaveOtte++)
            {
                opgaveOtteArray[opgaveOtte - 40] = opgaveOtte;
            }

            return opgaveOtteArray;
        }

        [HttpGet("Opgave 9")]
        public int[] OpgaveNi()
        {
            int[] opgaveNi = new int[5];
            var tal = 5;

            for (int i = 0; i < tal; i++)
            {
                opgaveNi[i] = i;
            }

            return opgaveNi;
        }

        [HttpGet("Opgave 10")]
        public int[] OpgaveTi()
        {
            int[] Opgave10 = new int[5];
            var tal1 = 5;
            var tal2 = 2;

            for (var i = tal2; i < tal1; i++)
            {
                // Opgave10[i - 2] = i;
                Opgave10[i - tal2] = i;
            }

            return Opgave10;
        }

        [HttpGet("Opgave 11")]
        public List<Seat> OpgaveElleve()
        {
            int[] opgaveElleveArray = new int[50];
            var tal1 = 5;
            var tal2 = 2;
            List<Seat> seatList = new List<Seat>();

            for (int i = tal2; i < tal1; i++)
            {
                Seat seat = new Seat();
                seat.RowNumber = 5;
                seatList.Add(seat);
            }

            return seatList;
        }

        [HttpGet("Seat Opgave")]
        public List<Seat> SeatOpgave()
        {
            int[] seatArray = new int[50];
            var row = 12;
            var column = 10;
            List<Seat> seatList = new List<Seat>();

            for (int i = column; i < row; i++)
            {
                for (int o = 0; o < 3; o++)
                {
                    Seat seat = new Seat();
                    seat.RowNumber = i;
                    seat.SeatNumber = o;
                    seatList.Add(seat);
                }
            }

            return seatList;
        }
    }
}
