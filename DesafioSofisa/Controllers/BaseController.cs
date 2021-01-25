﻿using Microsoft.AspNetCore.Mvc;

namespace DesafioSofisa.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected new IActionResult Response(object result = null)
        {
            var success = true;

            if (result == null)
            {
                success = false;
            }

            return Ok(new
            {
                success,
                data = result
            });
        }
    }
}
