using RotaVeiculos.Models;
using RotaVeiculos.Repositories;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Veiculo;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Veiculo;

namespace RotaVeiculos.Services
{
    public class VeiculoService : IVeiculoService
    {
        IVeiculoRepositorio _veiculoRepositorio;

        public VeiculoService(IVeiculoRepositorio veiculoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
        }

        public async Task<VeiculoViewModel> BuscarPorId(int id)
        {
            var response = await _veiculoRepositorio.BuscarPorId(id);
            var caminho = @"C:\RotaVeiculosImages\" + response.Imagem;
            byte[] bytesImagem = File.ReadAllBytes(caminho);
            var imagemBase64 = Convert.ToBase64String(bytesImagem);
            response.ImagemBase64 = imagemBase64;
            return response;
        }

        public async Task<List<VeiculoGridViewModel>> BuscarTodosVeiculos()
        {
            var response = await _veiculoRepositorio.BuscarTodosVeiculos();
            return response;
        }

        public async Task<VeiculoViewModel> Adicionar(VeiculoRequest veiculo)
        {
            string nomeArquivo = Guid.NewGuid().ToString();
            var extensao = veiculo.NomeImagem.Substring(veiculo.NomeImagem.LastIndexOf('.'));
            if(UploadArquivo(nomeArquivo, veiculo.ImagemBase64, extensao))
            {
                var response = await _veiculoRepositorio.Adicionar(veiculo, nomeArquivo + extensao);
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<VeiculoViewModel> Atualizar(int id, VeiculoRequest veiculo)
        {
            var veiculoViewModel = await BuscarPorId(id);
            Veiculo veiculoPorId = new Veiculo(veiculoViewModel.Id, veiculoViewModel.Nome, veiculoViewModel.Preco, veiculoViewModel.Quilometragem, veiculoViewModel.Placa, veiculoViewModel.DocumentosEmDia, veiculoViewModel.NomeImagem, veiculoViewModel.Imagem, veiculoViewModel.Ano, veiculoViewModel.TipoCombustivel, veiculoViewModel.Cor);
            string nomeArquivo = Guid.NewGuid().ToString();
            var extensao = veiculo.NomeImagem.Substring(veiculo.NomeImagem.LastIndexOf('.'));


            if (veiculoPorId != null)
            {
                if (UploadArquivo(nomeArquivo, veiculo.ImagemBase64, extensao))
                {
                    var response = await _veiculoRepositorio.Atualizar(id, veiculo, nomeArquivo + extensao);
                    return response;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("Veículo não foi encontrado");
            }
        }

        public async Task<bool> Deletar(int id)
        {
            var veiculoViewModel = await BuscarPorId(id);
            Veiculo veiculoPorId = new Veiculo(veiculoViewModel.Id, veiculoViewModel.Nome, veiculoViewModel.Preco, veiculoViewModel.Quilometragem, veiculoViewModel.Placa, veiculoViewModel.DocumentosEmDia, veiculoViewModel.NomeImagem, veiculoViewModel.Imagem, veiculoViewModel.Ano, veiculoViewModel.TipoCombustivel, veiculoViewModel.Cor);

            if (veiculoPorId != null)
            {
                var response = await _veiculoRepositorio.Deletar(id);
                return response;
            }
            else
            {
                throw new Exception("Veículo não foi encontrado");
            }
        }

        public bool UploadArquivo(string nomeArquivo, string arquivoBase64, string extensao)
        {
            var successFile = false;
            try
            {
                byte[] base64Bytes = Convert.FromBase64String(arquivoBase64);
                string pastaDestino = @"C:\RotaVeiculosImages";
                string caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo + extensao);
                File.WriteAllBytes(caminhoCompleto, base64Bytes);
                successFile = true;
            }
            catch(Exception)
            {
                
            }
            return successFile;
        }
    }
}
