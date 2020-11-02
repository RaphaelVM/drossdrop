﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using DrossDrop.DTOs;
using DrossDrop.Logic;
using DrossDrop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;

namespace DrossDrop.Controllers
{
    public class LoginController : Controller
    {
        private UserHandler handler = new UserHandler();
        private readonly EncryptionHelper helper = new EncryptionHelper();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            if (handler.AttemptLogin(model.email, model.password))
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            User user = new User()
            {
                firstName = model.firstName,
                lastName = model.lastName,
                email = model.email
            };

            handler.CreateUser(user, model.password);

            handler.AttemptLogin(model.email, model.password);

            return RedirectToAction("Index", "Home");
        }
    }
}
