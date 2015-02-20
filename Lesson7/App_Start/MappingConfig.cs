using AutoMapper;
using Lesson7.Model;
using Lesson7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson7.App_Start
{
    public static class MappingConfig
    {
        public static void AutoMap()
        {
            Mapper.CreateMap<Student, StudentModel>();
            Mapper.CreateMap<Course, CourseModel>();
            Mapper.CreateMap<StudentNota, StudentNotaModel>();

            Mapper.CreateMap<StudentModel, Student>();
            Mapper.CreateMap<CourseModel, Course>();
            Mapper.CreateMap<StudentNotaModel, StudentNota>();
        }
    }
}