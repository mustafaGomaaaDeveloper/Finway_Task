using AutoMapper;
using Finway.extantion;
using Finway.Interfaces;
using Finway.Models;
using Finway.Models.DTO;

namespace Finway.Services
{
    public class PersonService : Base<Person> , IPerson
    {
        private readonly IMapper _mapper;
        public PersonService(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public GenericResponse<List<Person>> Getpeople()
        {
            try
            {
                var result = GetAll();
                if (result.Status == EnumStatus.Fail)
                {
                    return new() { Status = EnumStatus.Fail, ResponseText = "There is no people " };
                }
                
                return new() { ResponseObject = result.ResponseObject.ToList(), Status = EnumStatus.Success, ResponseText = "Success" };
            }
            catch (Exception ex)
            {
                return new() { ResponseText = ex.Source, Status = EnumStatus.Fail };
            }
        }

        public GenericResponse<Person> GetPersonById(int id)
        {
            try
            {
                var result = Find(p=>p.Id==id);
                if (result.Status == EnumStatus.Fail)
                {
                    return new() { Status = EnumStatus.Fail, ResponseText = "There is no Person With this Id " };
                }

                return new() { ResponseObject = result.ResponseObject, Status = EnumStatus.Success, ResponseText = "Success" };
            }
            catch (Exception ex)
            {
                return new() { ResponseText = ex.Source, Status = EnumStatus.Fail };
            }
        }

        public GenericResponse<Person> UpdatePerson(PersonDto person,int id)
        {
            try
            {
                var personExisting = Find(person => person.Id == id);
                if (personExisting.Status == EnumStatus.Fail)
                {
                    return new() { Status = EnumStatus.Fail, ResponseText = "Can't Find the Person " };
                }              

                personExisting.ResponseObject.Email = person.Email;
                personExisting.ResponseObject.Country = person.Country;
                personExisting.ResponseObject.Name = person.Name;
                personExisting.ResponseObject.DateOfBirth = person.DateOfBirth;

                var updatedPerson=Update(personExisting.ResponseObject);
                if (updatedPerson.Status == EnumStatus.Fail)
                {
                    return new() { Status = EnumStatus.Fail, ResponseText = "Can't update Person " };
                }

                return new() { ResponseObject = updatedPerson.ResponseObject, Status = EnumStatus.Success, ResponseText = "Success" };
            }
            catch (Exception ex)
            {
                return new() { ResponseText = ex.Source, Status = EnumStatus.Fail };
            }
        }

        public GenericResponse<Person> InsertPerson(PersonDto person)
        {
            try
            {
               var newPerson = _mapper.Map<Person>(person);
               var result = Insert(newPerson);

                if (result.Status == EnumStatus.Fail)
                {
                    return new() { Status = EnumStatus.Fail, ResponseText = result.ResponseText };

                }

                return new() { ResponseObject = result.ResponseObject, Status = EnumStatus.Success, ResponseText = "Person Saved successfully " };
            }
            catch (Exception ex)
            {
                return new() { ResponseText = ex.Source, Status = EnumStatus.Fail };
            }
        }
    }
}
