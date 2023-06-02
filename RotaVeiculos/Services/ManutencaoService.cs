using RotaVeiculos.Models;
using RotaVeiculos.Repositories;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Manutencao;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Manutencao;

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
            return response;
        }

        public async Task<List<ManutencaoGridViewModel>> BuscarTodasManutencoes()
        {
            var response = await _manutencaoRepositorio.BuscarTodasManutencoes();
            return response;
        }

        public async Task<ManutencaoViewModel> Adicionar(ManutencaoRequest manutencao)
        {
            var response = await _manutencaoRepositorio.Adicionar(manutencao);
            return response;
        }

        public async Task<ManutencaoViewModel> Atualizar(int id, ManutencaoRequest manutencao)
        {
            var manutencaoViewModel = await BuscarPorId(id);
            Manutencao manutencaoPorId = new Manutencao(manutencaoViewModel.Id, manutencaoViewModel.Nome, manutencaoViewModel.Preco, manutencaoViewModel.ManutencaoRealizada, manutencaoViewModel.Placa);

            if (manutencaoPorId != null)
            {
                var response = await _manutencaoRepositorio.Atualizar(id, manutencao);
                return response;
            }
            else
            {
                throw new Exception("Manutenção não foi encontrada");
            }
        }

        public async Task<bool> Deletar(int id)
        {
            var manutencaoViewModel = await BuscarPorId(id);
            Manutencao manutencaoPorId = new Manutencao(manutencaoViewModel.Id, manutencaoViewModel.Nome, manutencaoViewModel.Preco, manutencaoViewModel.ManutencaoRealizada, manutencaoViewModel.Placa);

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
    }
}
