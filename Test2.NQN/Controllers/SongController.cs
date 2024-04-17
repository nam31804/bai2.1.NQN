using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test2.NQN.Models;
using static Test2.NQN.Models.SongController;

namespace Test2.NQN.Controllers
{
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index()
        {
            var songs = new List<Song>
        {
            new Song { Title = "Song 1", Artist = "Artist 1", FilePath = "/path/to/song1.mp3" },
            new Song { Title = "Song 2", Artist = "Artist 2", FilePath = "/path/to/song2.mp3" },
            new Song { Title = "Song 3", Artist = "Artist 3", FilePath = "/path/to/song3.mp3" }
        };

            return View(songs);
        }

        public FileResult Download(string filePath)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(filePath));
            string fileName = Path.GetFileName(filePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}