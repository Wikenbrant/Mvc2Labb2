using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mvc2Labb2.Models;
using Mvc2Labb2.ViewModels;

namespace Mvc2Labb2.Profiles
{
    public class ActorProfile:Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ListActorsViewModel.ActorViewModel>();
        }
    }
}
