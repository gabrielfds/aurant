/*Script para cria��o de categorias e status iniciais */
INSERT INTO PRODUCT_CATEGORY(CATEGORY_NAME)
VALUES('cds')

INSERT INTO PRODUCT_CATEGORY(CATEGORY_NAME)
VALUES('camisetas')

insert into PUBLICATION_STATUS(PBST_NM_STATUS,PBST_VL_STATUS)
values('DRAFT','DRAFT')


insert into PUBLICATION_STATUS(PBST_NM_STATUS,PBST_VL_STATUS)
values('PUBLISHED','PUBLISHED')


insert into PUBLICATION_STATUS(PBST_NM_STATUS,PBST_VL_STATUS)
values('HISTORY','HISTORY')