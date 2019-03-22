using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterRestDAL
{
    public class AuthDBContext : IdentityDbContext
    {
        //
        // Summary:
        //     Initializes a new instance of Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext.
        //
        // Parameters:
        //   options:
        //     The options to be used by a Microsoft.EntityFrameworkCore.DbContext.
        public AuthDBContext(DbContextOptions options) : base(options)
        { }
        //
        // Summary:
        //     Initializes a new instance of the Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
        //     class.

    }
}
