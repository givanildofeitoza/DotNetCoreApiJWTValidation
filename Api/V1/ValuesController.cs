using Api.DTO;
using Api.Extensions;
using Api.V1.Controllers;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Text;

namespace Api.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    [Authorize]
    public class ValuesController : MainController
    {
        protected readonly IInputRelationsService _InputRelationsService;
        private readonly IMapper _mapper;

       
        public ValuesController(IInputRelationsService InputRelationsService, 
                                IMapper mapper) 
        {
            _InputRelationsService = InputRelationsService;
            _mapper = mapper;    

        }
       
        [HttpGet("Get-Value-id/{Id}")]
        public async Task<ActionResult<DtoInputRelations>> GetById(int Id)
        {           
            var value = _mapper.Map<DtoInputRelations>(await _InputRelationsService.GetValueById(Id));
            return Ok(value);

        }
        [HttpPost("New-Value")]
        public async Task<ActionResult> PostValue([FromBody] DtoInputRelations NewValue)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
                        
            _InputRelationsService.PostValue(_mapper.Map<InputRelations>(NewValue));

            return Ok();
        }
        [HttpPost("Update-Value")]
        public async Task<ActionResult> PutValue([FromBody] DtoInputRelations NewValue)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            _InputRelationsService.PutValue(_mapper.Map<InputRelations>(NewValue));

            return Ok();
        }
        [HttpDelete("Delete-Value-id/{Id}")]
        public async Task<ActionResult> DeleteById(int Id)
        {
            await _InputRelationsService.DeleteValueById(Id);
            return Ok();
        }
        [AutorizacaoClaim("contas", "obtertodos")]
        [HttpGet("Get-ValuesAll/{Id}")]
        public async Task<ActionResult<IEnumerable<InputRelations>>> GetValuesAll(int id)
        {
           var AllValues = _mapper.Map<IEnumerable<DtoInputRelations>>( await _InputRelationsService.GetValuesAll());
           var ReturnByID = AllValues.Where(x => x.IdCustomer == id).ToList();


            return Ok(ReturnByID);
        }
    }
}
