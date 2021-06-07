using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using ReaderApi.Models;

namespace ReaderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : Controller
    {
        private ReaderRepository _readerRepository;

        public ReaderController(ReaderRepository readerRepository)
        {
            this._readerRepository = readerRepository;
        }
        [HttpPut]
        public IActionResult UpdateReader([FromBody] JObject data)
        {
            try
            {

                ReaderDTO reader = data.ToObject<ReaderDTO>();
                this._readerRepository.Update(reader);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error message: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateReader([FromBody] JObject data)
        {
            try
            {
                Reader reader = data.ToObject<Reader>();
                this._readerRepository.Create(reader);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error message: " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allReaders = this._readerRepository.GetAllReaders();

                return Ok(allReaders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error message: " + ex.Message);
            }
        }

        [HttpGet("{locationName}")]
        public IActionResult GetReaderByLocation(string locationName)
        {
            try
            {
                var allReaders = this._readerRepository.GetReadersByLocation(locationName);
                if (allReaders == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(allReaders);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error message: " + ex.Message);
            }
        }

        [HttpGet("history/{readerNumber}")]
        public IActionResult GetReaderHistoryByNumber(string readerNumber)
        {
            try
            {
                var allReaders = this._readerRepository.GetReaderHistoryByName(readerNumber);
                if (allReaders == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(allReaders);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error message: " + ex.Message);
            }
        }
    }

}
