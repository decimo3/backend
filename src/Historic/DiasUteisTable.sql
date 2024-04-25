UPDATE feriado SET referencia = (EXTRACT(YEAR FROM dia) * 100) + EXTRACT(MONTH FROM dia);
INSERT INTO dias_uteis (referencia, identificador, dias_uteis) VALUES
('2023-10-01', 202310, 22),
('2023-11-01', 202311, 22),
('2023-12-01', 202312, 21),
('2024-01-01', 202401, 23),
('2024-02-01', 202402, 21),
('2024-03-01', 202403, 21),
('2024-04-01', 202404, 22);
SELECT dias_uteis.identificador, dias_uteis.dias_uteis as dias_uteis_mes, feriado.feriados, dias_uteis.dias_uteis - feriado.feriados as dias_uteis FROM (SELECT referencia, COUNT(*) as feriados FROM feriado GROUP BY referencia) as feriado RIGHT JOIN dias_uteis ON dias_uteis.identificad
or = feriado.referencia;

-- SELECT composicao WITH JOIN objetivo
SELECT composicao.identificador, composicao.dia, composicao.recurso, composicao.atividade, composicao.id_motorista, composicao.id_ajudante, composicao.id_supervisor, objetivo.meta_producao, objetivo.meta_execucoes, (EXTRACT(YEAR FROM composicao.dia) * 100 + EXTRACT(MONTH FROM composicao.dia)) as referencia FROM composicao LEFT JOIN objetivo ON composicao.regional = objetivo.regional AND composicao.atividade = objetivo.atividade AND composicao.tipo_viatura = objetivo.tipo_viatura;
-- SELECT dias_uteis WITH JOIN refiado
SELECT dias_uteis.identificador, dias_uteis.dias_uteis, feriado.feriados, dias_uteis.dias_uteis - feriado.feriados as resultado FROM (SELECT referencia, COUNT(*) as feriados FROM feriado GROUP BY referencia) as feriado RIGHT JOIN dias_uteis ON dias_uteis.identificador = feriado.referencia;
--
--
--
SELECT composicao.identificador, composicao.dia, composicao.recurso, composicao.atividade, composicao.id_motorista, composicao.id_ajudante, composicao.id_supervisor, objetivo.meta_producao, objetivo.meta_execucoes, (EXTRACT(YEAR FROM composicao.dia) * 100 + EXTRACT(MONTH FROM composicao.dia)) AS referencia, dias_uteis_restantes.dias_uteis_mes, COALESCE(dias_uteis_restantes.feriados, 0) AS feriados, dias_uteis_restantes.dias_uteis, objetivo.meta_producao / dias_uteis_restantes.dias_uteis AS meta_diaria FROM composicao LEFT JOIN objetivo ON composicao.regional = objetivo.regional AND composicao.atividade = objetivo.atividade AND composicao.tipo_viatura = objetivo.tipo_viatura LEFT JOIN (SELECT dias_uteis.identificador, dias_uteis.dias_uteis as dias_uteis_mes, feriado.feriados, dias_uteis.dias_uteis - COALESCE(feriado.feriados, 0) AS dias_uteis FROM (SELECT referencia, COUNT(*) AS feriados FROM feriado GROUP BY referencia) AS feriado RIGHT JOIN dias_uteis ON dias_uteis.identificador = feriado.referencia) AS dias_uteis_restantes ON dias_uteis_restantes.identificador = EXTRACT(YEAR FROM composicao.dia) * 100 + EXTRACT(MONTH FROM composicao.dia);
