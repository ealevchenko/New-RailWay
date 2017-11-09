﻿using EFReference.Abstract;
using EFReference.Concrete;
using EFReference.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API_RailWay.Controllers
{
    [RoutePrefix("api/reference")]
    public class ReferenceController : ApiController
    {
        IReference rep_ref;

        #region cargo
        public ReferenceController()
        {
            this.rep_ref = new EFReference.Concrete.EFReference();
        }

        // GET: api/reference/cargo
        [Route("cargo/{id:int?}")]
        public IEnumerable<Cargo> GetCargo()
        {
            return this.rep_ref.GetCargo();
        }
        // GET: api/reference/cargo/id/5
        [Route("cargo/id/{id:int?}")]
        [ResponseType(typeof(Cargo))]
        public IHttpActionResult GetCargo(int id)
        {
            Cargo cargo = this.rep_ref.GetCargo(id);
            if (cargo == null)
            {
                return NotFound();
            }

            return Ok(cargo);
        }

        // GET: api/reference/cargo/etsng_code/32203
        [Route("cargo/etsng_code/{id:int}")]
        [ResponseType(typeof(Cargo))]
        public IHttpActionResult GetCargoOfCode(int id)
        {
            Cargo cargo = this.rep_ref.GetCorrectCargo(id);
            if (cargo == null)
            {
                return NotFound();
            }

            return Ok(cargo);
        }
        #endregion

    }
}
