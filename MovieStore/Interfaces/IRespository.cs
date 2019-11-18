using MovieStore.Models;
using MovieStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Interfaces
{
    public interface IRespository<T> where T : class //Custom Generic Interface
    {

        IEnumerable<T> GetAll(); //Index
        T GetById(int id); //Details  
        void Add(T obj);
        T Update(int id);//Get
        void Update(T obj);//Post
        //void Delete(int id);
        //void Delete(Movie movie);
    }  

    public interface IMovieExample
    {
        (string, string, DateTime) GetMovieDetailsById(int id);
    }
}
