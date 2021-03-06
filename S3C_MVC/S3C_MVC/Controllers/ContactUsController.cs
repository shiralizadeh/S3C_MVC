﻿using S3C_MVC.DataLayer;
using S3C_MVC.Models;
using S3C_MVC.Models.Public;
using S3C_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3C_MVC.Controllers
{
    public class ContactUsController : Controller
    {
        public ContactUsMessagesServices contactUsMessagesServices => new ContactUsMessagesServices();

        // GET: ContactUs
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.Title = "تماس با ما";

            return View();
        }

        [HttpPost]
        public ViewResult Index(ContactUsModel model)
        {
            if (model.Firstname == "ali")
                ModelState.AddModelError("aaa", "لطفا علی نباش!");

            if (ModelState.IsValid)
            {
                ContactUsModel.List.Add(model);

                // insert

                ViewBag.IsSuccess = true;
            }

            System.Threading.Thread.Sleep(5000);

            return View();
        }

        public bool SendMessage(ContactUsMessage contactUsMessage)
        {
            try
            {
                contactUsMessagesServices.Insert(contactUsMessage);
                System.Threading.Thread.Sleep(5000);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}