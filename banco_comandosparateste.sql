describe estoqueinsumo;

select * from estoqueinsumo;

update estoqueinsumo set qtd_insumo = 30 where id_insumo = 2;

select * from saidainsumo;

update cultivo set nome_cultivo = 'batata do igor 2' where id_cultivo = 63;

update estoqueinsumo set qtd_insumo = 10 where id_insumo = 1;

SELECT id_saidainsumo, qtd_saidainsumo, unidqtd_saidainsumo, data_saidainsumo FROM saidainsumo;

select * from producao;

SELECT id_insumo, nome_insumo, categoria_insumo, qtd_insumo, unidqtd_insumo, ativo_insumo 
                                FROM estoqueinsumo 
                                WHERE ativo_insumo = true AND qtd_insumo > 0;

UPDATE producao SET finalizado_producao = true, datacolheita_producao = @data WHERE id_producao = @id;

select * from estoqueproduto;

select * from compraitem;
select * from pedidocompra;