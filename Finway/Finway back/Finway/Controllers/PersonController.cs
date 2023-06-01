using AutoMapper;
using Finway.extantion;
using Finway.Interfaces;
using Finway.Models;
using Finway.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public PersonController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        [HttpGet("GetPeople")]
        public GenericResponse<List<Person>> GetPeople()
        {
            try
            {
               return _UnitOfWork.Person.Getpeople();
            }
            catch (Exception ex)
            {
                return new() { ResponseText = ex.Source, Status = EnumStatus.Fail };
            }
        }

        [HttpGet("GetPersonById")]
        public GenericResponse<Person> GetPersonById(int id)
        {
            try
            {
               return _UnitOfWork.Person.GetPersonById(id);

            }
            catch (Exception ex)
            {
                return new() { ResponseText = ex.Source, Status = EnumStatus.Fail };
            }
        }

        [HttpPost("InserPerson")]
        public GenericResponse<Person> InsertPerson(PersonDto person)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new() { ResponseText = ModelState.ToString(), Status = EnumStatus.Fail };


                return _UnitOfWork.Person.InsertPerson(person);

            }
            catch (Exception ex)
            {

                return new() { ResponseText = ex.Source, Status = EnumStatus.Fail };
            }
        }

        [HttpPost("UpdatePerson")]
        public GenericResponse<Person> UpdatePerson(PersonDto person,int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new() { ResponseText = ModelState.ToString(), Status = EnumStatus.Fail };

                return _UnitOfWork.Person.UpdatePerson(person,id);
            }
            catch (Exception ex)
            {
                return new() { ResponseText = ex.Source, Status = EnumStatus.Fail };
            }
        }

    }
}
