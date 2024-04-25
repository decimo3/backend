namespace backend.Models
{
  public partial class Servico
  {
    public void Timestamp()
    {
      if(hora_final == null) return;
      this.timestamp = dia.ToDateTime((System.TimeOnly)hora_final);
    }
    public void Valoracao()
    {
      // caso o id_processo seja inválido
      if(this.id_processo == 0)
      {
        this.id_grupo_codes = String.Empty;
        return;
      }
      // caso não tenha código preenchido
      if(String.IsNullOrEmpty(this.codigos))
      {
        this.id_grupo_codes = String.Empty;
        return;
      }
      // caso o tipo de serviço é CORTE
      if(this.id_processo == 1)
      {
        if(this.tem_ret_ramal && this.tem_ret_medidor)
        {
          this.id_grupo_codes = "R.MD";
          return;
        }
        if(this.tem_ret_medidor)
        {
          this.id_grupo_codes = "S.MD";
          return;
        }
        this.id_grupo_codes = this.codigos;
        return;
      }
      // caso o tipo de serviço é RELIGA
      if(this.id_processo == 2)
      {
        if(this.tem_inst_ramal && this.tem_inst_medidor)
        {
          this.id_grupo_codes = "R.MD";
          return;
        }
        if(this.tem_inst_medidor)
        {
          this.id_grupo_codes = "S.MD";
          return;
        }
        this.id_grupo_codes = this.codigos;
        return;
      }
      // caso o tipo de serviço é EMERGÊNCIA
      // TODO - Verificar o maior valor de
      // todos os códigos de finalização
      if(this.id_processo == 3)
      {
        this.id_grupo_codes = String.Empty;
        return;
      }
      // caso o tipo de serviço é INSPEÇÃO
      if(this.id_processo == 4)
      {
        this.id_grupo_codes = this.tem_iniciativa ? "I." : "S.";
        if(this.tem_inspecao == false)
        {
          this.id_grupo_codes += "NI";
          return;
        }
        if(this.tem_normalizacao == 0)
        {
          this.id_grupo_codes += "NA";
          return;
        }
        if(this.tem_normalizacao == 1)
        {
          var array = new bool[] {this.tem_inst_ramal, this.tem_inst_medidor, tem_ret_ramal, tem_ret_medidor};
          this.id_grupo_codes += Servico.IntToHex(Servico.BoolArrayToInt(array));
          this.id_grupo_codes += this.tem_normalizacao;
          return;
        }
        if(this.tem_normalizacao > 1)
        {
          this.id_grupo_codes += Servico.ZeroPadInteger(this.tem_normalizacao);
          return;
        }
      }
      this.id_grupo_codes = String.Empty;
      return;
    }
    public static Int32 BoolArrayToInt(Boolean[] array)
    {
      var valor = 0;
      for(var i = 0; i < array.Length; i++)
      {
        if(array[i]) valor |= 1 << i;
      }
      return valor;
    }
    public static String IntToHex(Int32 number)
    {
      return number.ToString("X8");
    }
    public static String ZeroPadInteger(Int32 number)
    {
      return number.ToString("D2");
    }
  }
}
