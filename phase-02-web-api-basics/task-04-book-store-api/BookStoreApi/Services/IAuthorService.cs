using System.Collections.Generic;
using BookStoreApi.DTOs;

namespace BookStoreApi.Services
{
    public interface IAuthorService 
    {

        AuthorResponse Create(CreateAuthorRequest request);
        IEnumerable<AuthorResponse> GetAll();
        bool Exists(int authorId);
        string GetNameById(int authorId);

        
    }
    
}