using backendnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace backendnet.Data.Seed;

public static class SeedIdentityUserData
{
    public static void SeedUserIdentityData(this ModelBuilder builder){
        //Agregar el rol "Administrador" a la tabla AspNetRoles
        string AdministradorRoleId = Guid.NewGuid().ToString();
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = AdministradorRoleId,
            Name = "Administrador",
            NormalizedName = "Administrador".ToUpper()
        });

        //agregar el rol "Usuario" a la tabla AspNetRoles
        string UsuarioRoleId = Guid.NewGuid().ToString();
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = UsuarioRoleId,
            Name = "Usuario",
            NormalizedName = "Usuario".ToUpper()
        });

        // Agregamos un usuario a la tabla AspNetUsers
        var UsuarioId = Guid.NewGuid().ToString();
        builder.Entity<CustomIdentityUser>().HasData(new CustomIdentityUser
        {
            Id = UsuarioId,
            UserName = "gvera@uv.mx",
            Email = "gvera@uv.mx",
            NormalizedEmail = "gvera@uv.mx".ToUpper(),
            Nombre = "Guillermo Humberto Vera Amaro",
            NormalizedUserName = "gvera@uv.mx".ToUpper(),
            PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "patito"),
            Protegido = true
        });


        // Aplicamos la relacion entre el usuario y el rol en la tabla AspNetUserRoles
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = AdministradorRoleId,
            UserId = UsuarioId
        });

        // Agregamos un usuario a la tabla AspNetUsers
        UsuarioId = Guid.NewGuid().ToString();
        builder.Entity<CustomIdentityUser>().HasData(new CustomIdentityUser
        {
            Id = UsuarioId,
            UserName = "patito@uv.mx",
            Email = "patito@uv.mx",
            NormalizedEmail = "patito@uv.mx".ToUpper(),
            Nombre = "Usuario patito",
            NormalizedUserName = "patito@uv.mx".ToUpper(),
            PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "patito"),
        });

        // Aplicamos la relacion entre el usuario y el rol en la tabla AspNetUserRoles
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = UsuarioRoleId,
            UserId = UsuarioId
        });
    }
        
    
}