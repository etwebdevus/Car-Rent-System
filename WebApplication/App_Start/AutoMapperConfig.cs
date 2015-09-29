using AutoMapper;
using ModelLayerClassLibrary.Entities;
using ModelLayerClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ViewModel.Model;
using WebApplication.ViewModel.Manufacturer;
using WebApplication.ViewModel.Client;
using WebApplication.ViewModel.Car;
using ModelLayerClassLibrary.Utils;
using ModelLayerClassLibrary.Enum;
using WebApplication.ViewModel.Rent;
using ModelLayerClassLibrary.Abstract;

namespace WebApplication.App_Start
{
    public static class MapperConfig
    {
        public static void RegisterMappers()
        {
            //------------MANUFACTURER------------//
            Mapper.CreateMap<Manufacturer, ManufacturerViewModel>();
            Mapper.CreateMap<ManufacturerViewModel, Manufacturer>();


            //------------MODEL------------//
            Mapper.CreateMap<Model, CreateEditModelViewModel>()
                .ForMember(dest => dest.Manufacturers, opt => opt.MapFrom(src =>
                    new SelectList((new ManufacturerRepository(new WebAppRentSysDbContext())).GetAll(), "ManufacturerID", "Name")));

            Mapper.CreateMap<CreateEditModelViewModel, Model>();

            Mapper.CreateMap<Model, ListDetailsDeleteModelViewModel>().ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Manufacturer.Name));

            Mapper.CreateMap<ListDetailsDeleteModelViewModel, Model>();


            //------------CAR------------//
            Mapper.CreateMap<Car, ListDetailsDeleteCarViewModel>()
                .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Model.Manufacturer.Name));
                //.ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.Name));

            Mapper.CreateMap<ListDetailsDeleteCarViewModel, Car>();

            Mapper.CreateMap<Car, CreateEditCarViewModel>()
                .ForMember(dst => dst.ManufacturerID, opt => opt.MapFrom(src => src.Model.ManufacturerID))
                .ForMember(dest => dest.Manufacturers, opt => opt.MapFrom(src =>
                    new SelectList((new ManufacturerRepository(new WebAppRentSysDbContext())).GetAll(), "ManufacturerID", "Name")))
                .ForMember(dest => dest.Models, opt => opt.MapFrom(src =>
                    new SelectList((new ModelRepository(new WebAppRentSysDbContext())).GetAll(), "ModelID", "Name")));

            Mapper.CreateMap<CreateEditCarViewModel, Car>();


            //------------CLIENT------------//
            Mapper.CreateMap<Client, ClientViewModel>();
                //.ForMember(dest => dest.AddressNumber, opt => opt.MapFrom(src => src.Address.Number))
                //.ForMember(dest => dest.AddressStreet, opt => opt.MapFrom(src => src.Address.Street))
                //.ForMember(dest => dest.AddressDistrict, opt => opt.MapFrom(src => src.Address.District))
                //.ForMember(dest => dest.AddressCity, opt => opt.MapFrom(src => src.Address.City))
                //.ForMember(dest => dest.AddressState, opt => opt.MapFrom(src => src.Address.State))
                //.ForMember(dest => dest.PhoneNumberDDD, opt => opt.MapFrom(src => src.PhoneNumber.DDD))
                //.ForMember(dest => dest.PhoneNumberPhone, opt => opt.MapFrom(src => src.PhoneNumber.Phone))
                //.ForMember(dest => dest.CreditCardName, opt => opt.MapFrom(src => src.CreditCard.Name))
                //.ForMember(dest => dest.CreditCardMonth, opt => opt.MapFrom(src => src.CreditCard.Month))
                //.ForMember(dest => dest.CreditCardYear, opt => opt.MapFrom(src => src.CreditCard.Year))
                //.ForMember(dest => dest.CreditCardNumber, opt => opt.MapFrom(src => src.CreditCard.Number))
                //.ForMember(dest => dest.CreditCardSecurityNumber, opt => opt.MapFrom(src => src.CreditCard.SecurityNumber));

            Mapper.CreateMap<ClientViewModel, Client>()
                .ForMember(dest => dest.CreditCard, opt => opt.MapFrom(src => new CreditCard()
                {
                    Name = src.CreditCardName,
                    Month = src.CreditCardMonth,
                    Year = src.CreditCardYear,
                    Number = src.CreditCardNumber,
                    SecurityNumber = src.CreditCardSecurityNumber
                }))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => new PhoneNumber()
                {
                    DDD = src.PhoneNumberDDD,
                    Phone = src.PhoneNumberPhone
                }))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address()
                {
                    Number = src.AddressNumber,
                    Street = src.AddressStreet,
                    District = src.AddressDistrict,
                    City = src.AddressCity,
                    State = src.AddressState
                }));


            //------------RENT------------//
            Mapper.CreateMap<Rent, RentViewModel>()
                .ForMember(dst => dst.PickupDate, opt => opt.MapFrom(src => src.PickupDate.ToString("dd/mm/yyyy")))
                .ForMember(dst => dst.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate.ToString("dd/mm/yyyy")))
                .ForMember(dst => dst.ManufacturerName, opt => opt.MapFrom(src => src.Car.Model.Manufacturer.Name))
                .ForMember(dst => dst.ModelName, opt => opt.MapFrom(src => src.Car.Model.Name))
                .ForMember(dst => dst.ModelEngine, opt => opt.MapFrom(src => src.Car.Model.Engine));
                //.ForMember(dst => dst.CarList, opt => opt.MapFrom(src => 
                //    {
                //        List<ListDetailsDeleteCarViewModel> carVMList = new List<ListDetailsDeleteCarViewModel>();
                //        List<Car> carList = (new CarRepository(new WebAppRentSysDbContext())).GetAll();
                //        foreach (Car car in carList)
                //        {
                //                carVMList.Add(Mapper.Map<Car, ListDetailsDeleteCarViewModel>(car));
                //        }
                //        return carVMList;
                //    }
                //))
                //.ForMember(dst => dst.UserList, opt => opt.MapFrom(src => 
                //    {
                //        List<ClientViewModel> userVMList = new List<ClientViewModel>();
                //        List<User> userList = (new UserRepository(new WebAppRentSysDbContext())).GetAll();
                //        foreach (User user in userList)
                //        {
                //                userVMList.Add(Mapper.Map<User, ClientViewModel>(user));
                //        }
                //        return userVMList;
                //    }
                //));
            Mapper.CreateMap<RentViewModel, Rent>()
                .ForMember(dst => dst.PickupDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dst => dst.ReturnDate, opt => opt.MapFrom(src => DateTime.Now.AddDays(src.Days)))
                .ForMember(dst => dst.Price, opt => opt.MapFrom(src => (new CarRepository(new WebAppRentSysDbContext())).GetByID(src.CarID).Price * src.Days));
        }
    }
}