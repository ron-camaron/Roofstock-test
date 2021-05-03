using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using rs_service.Application.Property.Queries.GetById;
using rs_service.Application.Property.Queries.GetAll;
using rs_service.Application.Property.Commands.Insert;
using rs_service.Application.Property.Commands.Update;

namespace rs_service.APICore.Controllers
{
    public class PropertyController : BaseController
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Json(await Mediator.Send(new GetByIdQuery { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await Mediator.Send(new GetAllQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate([FromBody] InsertPropertyCommand propertyInfo)
        {
            var property = await Mediator.Send(new GetByIdQuery { Id = propertyInfo.Id });

            if (property != null)
            {
                try
                {
                    var result = await Mediator.Send(new UpdatePropertyCommand
                    {
                        Id = propertyInfo.Id,
                        Address1 = propertyInfo.Address1,
                        Address2 = propertyInfo.Address2,
                        City = propertyInfo.City,
                        State = propertyInfo.State,
                        Zip = propertyInfo.Zip,
                        ZipPlus4 = propertyInfo.ZipPlus4,
                        YearBuilt = propertyInfo.YearBuilt,
                        ListPrice = propertyInfo.ListPrice,
                        MonthlyRent = propertyInfo.MonthlyRent
                    });

                    return Ok(result);
                }
                catch (Exception e)
                {
                    return Problem(e.Message, statusCode: 500);
                }
            }
            else
            {
                try
                {
                    var result = await Mediator.Send(new InsertPropertyCommand
                    {
                        Id = propertyInfo.Id,
                        Address1 = propertyInfo.Address1,
                        Address2 = propertyInfo.Address2,
                        City = propertyInfo.City,
                        State = propertyInfo.State,
                        Zip = propertyInfo.Zip,
                        ZipPlus4 = propertyInfo.ZipPlus4,
                        YearBuilt = propertyInfo.YearBuilt,
                        ListPrice = propertyInfo.ListPrice,
                        MonthlyRent = propertyInfo.MonthlyRent
                    });

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message, statusCode: 500);
                }
            }
        }
    }
}