using RotaVeiculos.Models;
using RotaVeiculos.Repositories;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Manutencao;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Manutencao;
using RotaVeiculos.ViewModels.Veiculo;

namespace RotaVeiculos.Services
{
    public class ManutencaoService : IManutencaoService
    {
        IManutencaoRepositorio _manutencaoRepositorio;

        public ManutencaoService(IManutencaoRepositorio manutencaoRepositorio)
        {
            _manutencaoRepositorio = manutencaoRepositorio;
        }

        public async Task<ManutencaoViewModel> BuscarPorId(int id)
        {
            var response = await _manutencaoRepositorio.BuscarPorId(id);
            var caminho = @"C:\Projetos\rota-veiculos-frontend\public\RotaVeiculosImages\" + response.Imagem;
            byte[] bytesImagem = File.ReadAllBytes(caminho);
            var imagemBase64 = Convert.ToBase64String(bytesImagem);
            response.ImagemBase64 = imagemBase64;
            return response;
        }

        public async Task<List<ManutencaoGridViewModel>> BuscarTodasManutencoes(string nome)
        {
            var response = await _manutencaoRepositorio.BuscarTodasManutencoes(nome);
            return response;
        }

        public async Task<ManutencaoViewModel> Adicionar(ManutencaoRequest manutencao)
        {
            string nomeArquivo = Guid.NewGuid().ToString();
            var extensao = manutencao.NomeImagem.Substring(manutencao.NomeImagem.LastIndexOf('.'));
            
            if (UploadArquivo(nomeArquivo, manutencao.ImagemBase64, extensao))
            {
                var response = await _manutencaoRepositorio.Adicionar(manutencao, nomeArquivo + extensao);
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<ManutencaoViewModel> Atualizar(int id, ManutencaoRequest manutencao)
        {
            var manutencaoViewModel = await BuscarPorId(id);
            Manutencao manutencaoPorId = new Manutencao(manutencaoViewModel.Id, manutencaoViewModel.Nome, manutencaoViewModel.Preco, manutencaoViewModel.ManutencaoRealizada, manutencaoViewModel.Placa, manutencaoViewModel.NomeImagem, manutencaoViewModel.Imagem);
            string nomeArquivo = Guid.NewGuid().ToString();
            var extensao = manutencao.NomeImagem.Substring(manutencao.NomeImagem.LastIndexOf('.'));

            if (manutencaoPorId != null)
            {
                if (UploadArquivo(nomeArquivo, manutencao.ImagemBase64, extensao))
                {
                    var response = await _manutencaoRepositorio.Atualizar(id, manutencao, nomeArquivo + extensao);
                    return response;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("Manutenção não foi encontrada");
            }
        }

        public async Task<bool> Deletar(int id)
        {
            var manutencaoViewModel = await BuscarPorId(id);
            Manutencao manutencaoPorId = new Manutencao(manutencaoViewModel.Id, manutencaoViewModel.Nome, manutencaoViewModel.Preco, manutencaoViewModel.ManutencaoRealizada, manutencaoViewModel.Placa, manutencaoViewModel.NomeImagem, manutencaoViewModel.Imagem);

            if (manutencaoPorId != null)
            {
                var response = await _manutencaoRepositorio.Deletar(id);
                return response;
            }
            else
            {
                throw new Exception("Manutenção não foi encontrada");
            }
        }

        public bool UploadArquivo(string nomeArquivo, string arquivoBase64, string extensao)
        {
            var successFile = false;
            try
            {
                byte[] base64Bytes = Convert.FromBase64String(arquivoBase64);
                string pastaDestino = @"C:\Projetos\rota-veiculos-frontend\public\RotaVeiculosImages";
                string caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo + extensao);
                File.WriteAllBytes(caminhoCompleto, base64Bytes);
                successFile = true;
            }
            catch (Exception)
            {

            }
            return successFile;
        }
    }
}
