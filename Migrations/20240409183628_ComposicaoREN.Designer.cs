﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.Services;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20240409183628_ComposicaoREN")]
    partial class ComposicaoREN
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.Alteracao", b =>
                {
                    b.Property<long>("identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("identificador"));

                    b.Property<int>("responsavel")
                        .HasColumnType("integer");

                    b.Property<string>("tabela")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("valorAnterior")
                        .HasColumnType("text");

                    b.Property<string>("valorPosterior")
                        .HasColumnType("text");

                    b.Property<string>("verbo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("identificador");

                    b.ToTable("alteracao");
                });

            modelBuilder.Entity("backend.Models.Composicao", b =>
                {
                    b.Property<DateOnly>("dia")
                        .HasColumnType("date");

                    b.Property<string>("recurso")
                        .HasColumnType("text");

                    b.Property<string>("abreviacao")
                        .HasColumnType("text");

                    b.Property<int?>("adesivo")
                        .HasColumnType("integer");

                    b.Property<string>("ajudante")
                        .HasColumnType("text");

                    b.Property<int>("atividade")
                        .HasColumnType("integer");

                    b.Property<string>("controlador")
                        .HasColumnType("text");

                    b.Property<int>("id_ajudante")
                        .HasColumnType("integer");

                    b.Property<int?>("id_controlador")
                        .HasColumnType("integer");

                    b.Property<int>("id_motorista")
                        .HasColumnType("integer");

                    b.Property<int>("id_supervisor")
                        .HasColumnType("integer");

                    b.Property<string>("identificador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("justificada")
                        .HasColumnType("text");

                    b.Property<string>("motorista")
                        .HasColumnType("text");

                    b.Property<string>("placa")
                        .HasColumnType("text");

                    b.Property<int>("regional")
                        .HasColumnType("integer");

                    b.Property<int>("setor")
                        .HasColumnType("integer");

                    b.Property<string>("situacao")
                        .HasColumnType("text");

                    b.Property<string>("supervisor")
                        .HasColumnType("text");

                    b.Property<string>("tecnico")
                        .HasColumnType("text");

                    b.Property<long>("telefone")
                        .HasColumnType("bigint");

                    b.Property<int>("tipo_viatura")
                        .HasColumnType("integer");

                    b.HasKey("dia", "recurso");

                    b.HasIndex("identificador")
                        .IsUnique();

                    b.ToTable("composicao");
                });

            modelBuilder.Entity("backend.Models.Contrato", b =>
                {
                    b.Property<string>("contrato")
                        .HasColumnType("text");

                    b.Property<DateOnly>("final_vigencia")
                        .HasColumnType("date");

                    b.Property<DateOnly>("inicio_vigencia")
                        .HasColumnType("date");

                    b.Property<int>("regional")
                        .HasColumnType("integer");

                    b.HasKey("contrato");

                    b.ToTable("contrato");
                });

            modelBuilder.Entity("backend.Models.DiasUteis", b =>
                {
                    b.Property<int>("identificador")
                        .HasColumnType("integer");

                    b.Property<short>("dias_uteis")
                        .HasColumnType("smallint");

                    b.Property<DateOnly>("referencia")
                        .HasColumnType("date");

                    b.HasKey("identificador");

                    b.ToTable("dias_uteis");
                });

            modelBuilder.Entity("backend.Models.Feriado", b =>
                {
                    b.Property<DateOnly>("dia")
                        .HasColumnType("date");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("referencia")
                        .HasColumnType("integer");

                    b.Property<int>("regional")
                        .HasColumnType("integer");

                    b.Property<int>("tipo_feriado")
                        .HasColumnType("integer");

                    b.HasKey("dia");

                    b.ToTable("feriado");
                });

            modelBuilder.Entity("backend.Models.Funcionario", b =>
                {
                    b.Property<int>("matricula")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("admissao")
                        .HasColumnType("date");

                    b.Property<int?>("atividade")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("demissao")
                        .HasColumnType("date");

                    b.Property<int>("funcao")
                        .HasColumnType("integer");

                    b.Property<int?>("id_superior")
                        .HasColumnType("integer");

                    b.Property<string>("nome_colaborador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("palavra")
                        .HasColumnType("text");

                    b.Property<int?>("regional")
                        .HasColumnType("integer");

                    b.Property<int>("situacao")
                        .HasColumnType("integer");

                    b.HasKey("matricula");

                    b.ToTable("funcionario");
                });

            modelBuilder.Entity("backend.Models.Objetivos", b =>
                {
                    b.Property<int>("regional")
                        .HasColumnType("integer");

                    b.Property<int>("tipo_viatura")
                        .HasColumnType("integer");

                    b.Property<int>("atividade")
                        .HasColumnType("integer");

                    b.Property<string>("contrato")
                        .HasColumnType("text");

                    b.Property<int>("meta_apresentacao")
                        .HasColumnType("integer");

                    b.Property<int>("meta_apresentacao_feriado")
                        .HasColumnType("integer");

                    b.Property<int>("meta_execucoes")
                        .HasColumnType("integer");

                    b.Property<decimal>("meta_producao")
                        .HasColumnType("money");

                    b.HasKey("regional", "tipo_viatura", "atividade");

                    b.ToTable("objetivo");
                });

            modelBuilder.Entity("backend.Models.RelatorioEstatisticas", b =>
                {
                    b.Property<string>("filename")
                        .HasColumnType("text");

                    b.Property<DateOnly>("dia")
                        .HasColumnType("date");

                    b.Property<int>("recursos")
                        .HasColumnType("integer");

                    b.Property<int>("servicos")
                        .HasColumnType("integer");

                    b.HasKey("filename");

                    b.ToTable("relatorioEstatisticas");
                });

            modelBuilder.Entity("backend.Models.Servico", b =>
                {
                    b.Property<long>("serial")
                        .HasColumnType("bigint");

                    b.Property<string>("abreviacao")
                        .HasColumnType("text");

                    b.Property<string>("area_trabalho")
                        .HasColumnType("text");

                    b.Property<string>("bairro_destino")
                        .HasColumnType("text");

                    b.Property<string>("cidade_destino")
                        .HasColumnType("text");

                    b.Property<string>("codigo_postal")
                        .HasColumnType("text");

                    b.Property<string>("codigos")
                        .HasColumnType("text");

                    b.Property<string>("complemento_destino")
                        .HasColumnType("text");

                    b.Property<double?>("debitos_cliente")
                        .HasColumnType("double precision");

                    b.Property<TimeSpan?>("desloca_estima")
                        .HasColumnType("interval");

                    b.Property<TimeSpan?>("desloca_feito")
                        .HasColumnType("interval");

                    b.Property<DateOnly>("dia")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("duracao_estima")
                        .HasColumnType("interval");

                    b.Property<TimeSpan?>("duracao_feito")
                        .HasColumnType("interval");

                    b.Property<string>("endereco_destino")
                        .HasColumnType("text");

                    b.Property<string>("filename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly?>("hora_final")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly?>("hora_inicio")
                        .HasColumnType("time without time zone");

                    b.Property<int?>("id_ajudante")
                        .HasColumnType("integer");

                    b.Property<int?>("id_motorista")
                        .HasColumnType("integer");

                    b.Property<int?>("id_tecnico")
                        .HasColumnType("integer");

                    b.Property<string>("id_viatura")
                        .HasColumnType("text");

                    b.Property<string>("identificador")
                        .HasColumnType("text");

                    b.Property<int?>("instalacao")
                        .HasColumnType("integer");

                    b.Property<string>("motivo_indisponibilidade")
                        .HasColumnType("text");

                    b.Property<string>("nome_do_cliente")
                        .HasColumnType("text");

                    b.Property<string>("observacao")
                        .HasColumnType("text");

                    b.Property<string>("recurso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("referencia_destino")
                        .HasColumnType("text");

                    b.Property<long?>("servico")
                        .HasColumnType("bigint");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<string>("tipo_atividade")
                        .HasColumnType("text");

                    b.Property<int?>("tipo_instalacao")
                        .HasColumnType("integer");

                    b.Property<string>("tipo_servico")
                        .HasColumnType("text");

                    b.Property<DateTime?>("vencimento")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("serial");

                    b.HasIndex("identificador");

                    b.ToTable("relatorio");
                });

            modelBuilder.Entity("backend.Models.Valoracao", b =>
                {
                    b.Property<int>("regional")
                        .HasColumnType("integer");

                    b.Property<int>("tipo_viatura")
                        .HasColumnType("integer");

                    b.Property<int>("atividade")
                        .HasColumnType("integer");

                    b.Property<string>("codigo")
                        .HasColumnType("text");

                    b.Property<string>("contrato")
                        .HasColumnType("text");

                    b.Property<decimal>("valor")
                        .HasColumnType("money");

                    b.HasKey("regional", "tipo_viatura", "atividade", "codigo");

                    b.ToTable("valoracao");
                });
#pragma warning restore 612, 618
        }
    }
}
