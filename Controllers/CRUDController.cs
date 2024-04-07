using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using StringConverter.Data;
using StringConverter.Data.Interfaces;
using StringConverter.Data.Repositories;
using StringConverter.Models.Domain;
using StringConverter.Models.Dto;
using StringConverter.Models.ViewModel;
using System;
using System.Net.Security;
using System.Text.Json;

namespace StringConverter.Controllers
{
    [Authorize]
    public class CRUDController : Controller
    {
        private readonly IStringConverterRepository _repository;
        private readonly ITranslateText _translate;

        public CRUDController( IStringConverterRepository repository ,ITranslateText translate) 
        {
            _repository = repository;
            _translate = translate; 
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }




        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult?> Add(AddRequest addRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var translate = await _translate.TranslateText(addRequest.InputText);
                    TblConvertString save = new TblConvertString()
                    {
                        DataField = translate,
                    };
                    _repository.Add(save);
                    return RedirectToAction(nameof(GetText));
                }
                //_logger.LogInformation("Model State is Invalid");

                return StatusCode(400, "Bad Request");
            }
            catch (Exception)
            {

                throw new ArgumentException("Error occured");
            }
        }

        [HttpGet]

        public async Task<IActionResult?> GetText()
        {
           
                var getData = new GetViewModel();
                FormattableString fetch = $"[dbo].[spcGetTranslatedText]";
                var gets = await _repository.GetAllAsync(fetch);             
                getData.TblConvertStrings = gets;
                if (getData is null)
                {
                return StatusCode(400, "Not Found");
                }
                return View(getData);
         
        }

        #region
        //[HttpPut]
        //public async Task<IActionResult> UpdateTranslator(Guid Id, UpdateDto update)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest();
        //        }
        //        var translatex = await _translate.TranslateText(update.DataField);
        //        var query = new TblConvertString()
        //        {
        //            UserIDpk = Id,
        //            DataField = translatex
        //        };
        //        var response = _repository.Update(query);
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine("{0}",ex.Message);
        //    }
        //    return default;
        //}

        //[HttpDelete]

        //public async Task<IActionResult> Delete(Guid Id)
        //{
            
        //    var del =  _repository.Delete(Id);

        //    return Ok(del);
        //}
        #endregion
    }

}
