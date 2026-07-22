using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace AssalceFolha.Entity
{

    public class Enumerator<T>
    {

        public IDictionary<int, string> GetAll()
        {
            var enumerationType = typeof(T);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var dictionary = new Dictionary<int, string>();

            foreach (int value in Enum.GetValues(enumerationType))
            {
                var name = EnumDescription(IntToEnum(value));
                dictionary.Add(value, name);
            }

            return dictionary;
        }

        public T IntToEnum(int _id)
        {
            var enumerationType = typeof(T);
            return (T)Enum.Parse(enumerationType, _id.ToString());
        }

        public string IntToString(int _id)
        {
            var enumerationType = typeof(T);
            T _enum = (T)Enum.Parse(enumerationType, _id.ToString());

            return EnumDescription(_enum);
        }

        public int EnumToInt(object obj)
        {
            return ((int)obj);
        }
        public string EnumToString(object _obj)
        {
            return EnumDescription(_obj);
        }


        public static string EnumDescription(object _obj)
        {
            Type _type = _obj.GetType();
            DescriptionAttribute[] att = { };

            if (Enum.IsDefined(_type, _obj))
            {
                FieldInfo fieldInfo = _type.GetField(_obj.ToString());
                att = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return (att.Length > 0 ? att[0].Description ?? "Nulo" : _obj.ToString());
        }
    }

    #region Enumerator
    public enum enumEstadoCivil
    {
        [Description("Não Informado")]
        NaoInformado = 1,
        Solteiro = 2,
        Casado = 3,
        [Description("Viúvo")]
        Viuvo = 4,
        Divorciado = 5,
        [Description("Separado com Pensão Alimentícia")]
        SeparadocomPensaoAlimenticia = 6,
        [Description("Separado sem Pensão Alimentícia")]
        SeparadosemPensaoAlimenticia = 7,
        [Description("Separado Judicialmente")]
        SeparadoJudicialmente = 8,
        [Description("união Estável")]
        UniaoEstavel = 9
    }

    public enum enumSexo
    {
        Masculino = 1,
        Feminino = 2
    }

    public enum enumTipoConta
    {
        [Description("Conta Corrente")]
        ContaCorrente = 1,
        [Description("Conta Poupança")]
        ContaPoupança = 2
    }

    public enum enumMes
    {
        Janeiro = 1,
        Fevereiro = 2,
        [Description("Março")]
        Marco = 3,
        Abril = 4,
        Maio = 5,
        Junho = 6,
        Julho = 7,
        Agosto = 8,
        Setembro = 9,
        Outubro = 10,
        Novembro = 11,
        Dezembro = 12
    }

    public enum enumRelatorio
    {
        [Description("Conferência Carga Arquivo Folha")]
        ConferenciaCargaArquivoFolha = 1,
        [Description("Mapa CSG")]
        MapaCSG = 2,
        [Description("Crítica Folha")]
        CriticaFolha = 3,
        [Description("Retorno Folha")]
        RetornoFolha = 4,
        [Description("Comanda")]
        Comanda = 5,
        [Description("Envio Folha")]
        EnvioFolha = 6,
        [Description("Extrato de Comandas")]
        ExtratoComandas = 7,
        [Description("Aniversários")]
        Aniversarios = 8,
        [Description("Adiantamento")]
        Adiantamento = 9,
        [Description("Mensagem Aniversário")]
        MensagemAniversario = 10,
        [Description("Resumo Convênios")]
        ResumoConvenio = 11,
        [Description("Dados Associado")]
        DadosAssociado = 12,
        [Description("Comparativo Envio x Retorno Folha")]
        ComparativoEnvioRetornoFolha = 13,
        [Description("Inclusão de Modalidade no Clube do Vôlei")]
        InclusaoModalidadeClubeDoVolei = 14,
        [Description("Declaração Hap Vida")]
        DeclaracaoHapVida = 15,
        [Description("Convênio na Competência")]
        ConvenioCompetencia= 16,
        [Description("Declaração Unimed")]
        DeclaracaoUnimed = 17,
    }

    public enum enumTipoCobranca
    {
        Folha = 1,
        Boleto = 2
    }
    public enum enumTipoEndereco
    {
        Residencial = 1,
        Comercial = 2
    }

    public enum enumStatusFolha
    {
        Pendente = 1,
        Paga = 2
    }

    public enum enumTipoFolha
    {
        Adiantamento = 1,
        Mensal = 2
    }

    public enum enumTipoTelefone
    {
        Residencial = 1,
        Comercial = 2,
        Celular = 3,
        Fax = 4
    }

    public enum enumNivelSeguranca
    {
        PESSOAL = 1,
        ADM = 2
    }
    public enum enumTipoFeriado
    {
        Normal = 1,
        Nobre = 2
    }


    public enum enumTipoHorarioGuia
    {
        Normal = 1,
        Especial = 2
    }
    public enum enumFormulaBasePensaoAlimenticia
    {
        [Description("Bruto")]
        Bruto = 1,
        [Description("Bruto-IR")]
        BrutoIR = 2
    }

    public enum enumTipoContaInformacaoIRF
    {
        [Description("Nenhum")]
        Nenhum = 1,
        [Description("Rendimento")]
        Rendimento = 2,
        [Description("Dedução")]
        Deducao = 3
    }

    public enum enumNaturezaContaInformacaoIRF
    {
        [Description("Base de Cálculo")]
        BaseCalculo = 1,
        [Description("Resultado")]
        Resultado = 2
    }

    public enum enumTipoRentencaoIRF
    {
        TrabalhoAssalariado = 561,
        Resgate = 3223
    }
    public enum enumTipoProcessoInformacaoIRF
    {
        Original = 1, Retificadora = 2
    }

    public enum enumCategoriaContaIRF
    {
        [Description("Rendimento Tributável")]
        RendimentoTributavel = 1,
        [Description("Rendimento Isento por Moléstia")]
        RendimentoIsentoMolestia = 2,
        [Description("Rendimento Isento por Idade maior 65 anos")]
        RendimentoIsentoIdadeMaior65Anos = 3
    }


    public enum enumMenu
    {
        Pessoa = 1010,
        Funcao = 1015,
        Especialidade = 1020,
        PessoaFisica = 1025,
        PessoaJuridica = 1026,
        GrauInstrucao = 1035,
        TipoDocumento = 1045,
        OrgaoExpedidor = 1050,
        Usuários = 1060,
        PerfilAcesso = 1065,
        Consignatario = 2070,
        TabelaFeriado = 1070,
        Lotacao = 1075,
        ProcedimentosMedicos = 1090,
        Banco = 1100,
        Agencia = 1150,
        ConfiguracaoSEFIP = 1200,
        Contrato = 2005,
        TipoVerbaFaturamento = 1091,
        AjusteBiometria = 7100,
        Plantao = 2015,
        Guia = 2020,
        Glosa = 2030,
        ConsultaPlantao = 3005,
        ProcessoFaturamento = 2040,
        ProcessoFolhaPagamento = 4050,
        ProcessoInformacaoIRF = 3005,
        LancamentoManual = 4008,
        DeclaracaoINSS = 4009,
        PensaoAlimenticia = 4010,
        RelatorioDemonstrativoPagamento = 5010,
        RelatorioFolhaConsolidada = 5020,
        RelatorioExtratoRepassePorContratante = 7600,
        RelatorioEnvioArquivoBancario = 7700,
        RelatorioPlantaoPorHospital = 5030,
        RelatorioPlantaoBiometria = 7400,
        RelatorioPlantaoPorPessoa = 5050,
        RelatorioFaturamentoMes = 5040,
        RelatorioGuiaPorHospital = 5080,
        RelatorioGuiaPorPessoa = 5090,
        RelatorioDetalhamentoFolha = 5100,
        RelatorioExtratoRepasse = 5200,
        RelatorioExtratoRepasseAgrupado = 5250,
        RelatorioPagamentoConvenioPessoa = 5300,
        RelatorioespelhoPonto = 8000,
        RelatorioListaVinculo = 8200,
        RelatorioResumoPlantaoBiometrico = 8300,
        LeitorBiometrico = 7800,
        Vinculo = 7900,
        ExcecaoBiometrio = 8350,
        Escala = 2010,
        RelatorioEscalaCooperado = 8380,
        RelatorioEscalaPorLotacao = 8390,
        Turno = 1910,
        HorarioTrabalho = 1900,

        AutorizacaoBiometriaSemEscala = 99999,
        RelatorioSemEscala = 99998
    }

    public enum enumTipoDadoParametro
    {
        Texto = 1,
        Data = 2,
        FatorFinanceiro = 3,
        ValorMonetário = 4,
        ValorPercentual = 5,
        ValorCota = 6,
        ValorMatemáticoComplexo = 7,
        Inteiro = 8,
        Booleano = 9
    }

    public enum enumdiaSemana
    {
        Domingo = 1,
        [Description("Segunda-Feira")]
        Segunda = 2,
        [Description("Terça-Feira")]
        Tercao = 3,
        [Description("Quarta-Feira")]
        Quarta = 4,
        [Description("Quinta-Feira")]
        Quinta = 5,
        [Description("Sexta-Feira")]
        Sexta = 6,
        [Description("Sábado")]
        Sabado = 7
    }

    public enum enumConsulta
    {
        [Description("SN Planos de Saúde")]
        SNPlanoSaude = 1,
        [Description("SN Competência")]
        SNCompetencia = 2,
        [Description("SN Terceirizados")]
        SNTerceirizados = 3,
        [Description("Terceirizados Com Farmácia")]
        TerceirizadosComFarmacia = 4,
        [Description("Resumo Comandas No Ano")]
        ResumoComandasAno = 5,
        [Description("SN Com Farmácia")]
        SNComFarmacia = 6,
        [Description("Resumo Consignações")]
        ResumoConsignacoes = 7,
    }

    public enum enumPlanoHapVida
    {
        [Description("00229")]
        ID_00229 = 229,
        [Description("03EL0")]
        ID_EL0 = 2,
    }


    public enum enumTipoVencimento
    {
        Antecipado = 1,
        Postergado = 2
    }

    public enum enumTipoValorPlantao
    {
        [Description("Normal")]
        Normal = 1,
        [Description("Feriado")]
        Feriado = 2,
        [Description("Feriado Nobre")]
        FeriadoNobre = 3
    }

    public enum enumVerbaFolha
    {
        [Description("Bruto")]
        Bruto = 1,
        [Description("Imposto de Renda")]
        ImpostoRenda = 2,
        INSS = 3,
        [Description("Pensão de Alimento")]
        PensaoAlimento = 4,
        [Description("Líquido")]
        Liquido = 5,
        [Description("Qtde Dependentes IR")]
        QtdeDependentesIR = 6,
        [Description("Dedução Dependentes IR")]
        DeducaoDependentesIR = 7,
        [Description("Base IR")]
        BaseIR = 8,
        [Description("Dedução Idade")]
        DeducaoIdade = 9,
        [Description("Total Proventos")]
        TotalProventos = 10,
        [Description("Total Descontos")]
        TotalDescontos = 12,
        [Description("Outros Créditos")]
        OutrosCreditos = 13,
        [Description("Outros Débitos")]
        OutrosDebitos = 14,
        [Description("Tarifa bancária")]
        TarifaBancaria = 15,
        [Description("Dedução INSS")]
        DeducaoINSS = 16,
        [Description("Isenção IR")]
        IsencaoIR = 18,
        [Description("FPIF")]
        FPIF = 19,
        [Description("Insalubridade")]
        Insalubridade = 20,
        [Description("Repouso Semanal")]
        RepousoSemanal = 21
    }

    public enum enumTipoLancamento
    {
        [Description("Crédito")]
        Credito = 1,
        [Description("Débito")]
        Debito = 2,
    }

    public enum enumTipoParametro
    {
        [Description("Taxa de juros adiantamento")]
        TaxaJurosAdiantamento = 1,
        [Description("Dia fechamento adiantamento")]
        DiaFechamentoAdiantamento = 2,
        [Description("Convenio adiantamento")]
        ConvenioAdiantamento = 3,
        [Description("Dia virada mês")]
        DiaViradaMes = 4
    }

    public enum enumTipoConvenio
    {
        [Description("Compras")]
        Compras = 1,
        [Description("Financiamentos")]
        Financiamentos = 2,
        [Description("Planos")]
        Planos = 3,
        [Description("Bancos")]
        Bancos = 4
    }

    public enum enumTarifaBancaria
    {
        TED = 1,
        DOC = 2
    }

    public enum enumTipoPessoa
    {
        [Description("Pessoa Física")]
        Fisica = 1,
        [Description("Pessoa jurídica")]
        Juridica = 2
    }

    public enum enumTipoQuota
    {
        [Description("Quota Referente a Inscrição")]
        Inscricao = 1,
        [Description("Quota Referente a Participação")]
        Participacao = 2,
    }

    public enum enumStatusPagamento
    {
        Aberto = 1,
        Pago = 2,
        Cancelado = 3
    }

    #region SEFIP


    public enum enumTipoRemessaSEFIP
    {
        GFIP = 1,
        DERF = 3
    }

    public enum enumTipoIncricaoSEFIP
    {
        CNPJ = 1,
        CEI = 2,
        CPF = 3
    }

    public enum enumIndicadorRecolhimentoSEFIP
    {
        GFIPnoPrazo = 1,
        GFIPemAtraso = 2
    }


    #endregion

    #endregion
}
