﻿using AscFrontEnd.DTOs.StaticsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.Application
{
    public class Documento
    {
        public static async Task<string> GetCodigoDocumentoAsync(string documento) 
        {
            string codigoDocumento = null;
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"https://localhost:7200/api/serie/codigoDocumento/{documento}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    string dados = content.ToString();

                    codigoDocumento = dados;
                }
                return codigoDocumento;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Erro ao carregar o codigo do documento {ex.Message}");
            }
        }
    }
}