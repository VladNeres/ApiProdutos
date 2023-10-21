using Domain.ViewlModels;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Paginacao<T> 
    {
        public Paginacao(int totalCount,T data, int currentPageNumber, int pageSize)
        {
            TotalCount = totalCount;
            Data = data;
            CurrentPageNumber = currentPageNumber;
            PageSize = pageSize;
            
            
            TotalPages = (int)Math.Ceiling((double)TotalCount / (double)PageSize);
            HasPreviewPage = CurrentPageNumber > 1;
            HasNextPages = CurrentPageNumber < TotalPages;
        }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviewPage { get; set; }
        public bool HasNextPages { get; set; }

        public T Data { get; set; }

       
    }
}
