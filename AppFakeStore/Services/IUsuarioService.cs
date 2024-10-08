﻿using AppFakeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFakeStore.Services
{
    public interface IUsuarioService
    {
        // Nueva interfaz para usuarios
        Task<IEnumerable<Usuario>> GetUsersAsync();
    }
}
