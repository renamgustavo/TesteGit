CREATE TABLE [veiculos] (
    [codigo] INTEGER IDENTITY(1,1) NOT NULL,
    [descricao] VARCHAR(100) NOT NULL,
    [cliente] INTEGER NOT NULL,
    [modelo] INTEGER NOT NULL,
    [valor] DECIMAL(8,2) NOT NULL,
    [datacadastro] DATE NOT NULL,
    [datavenda] DATE,
    [observacoes] VARCHAR(200),
    [ativo] CHAR(1) NOT NULL,
    CONSTRAINT [PK_veiculos] PRIMARY KEY ([codigo])
)
GO

CREATE TABLE [fabricantes] (
    [codigo] INTEGER IDENTITY(1,1) NOT NULL,
    [nome] VARCHAR(30) NOT NULL,
    CONSTRAINT [PK_fabricantes] PRIMARY KEY ([codigo])
)
GO

CREATE TABLE [modelos] (
    [codigo] INTEGER IDENTITY(1,1) NOT NULL,
    [descricao] VARCHAR(30) NOT NULL,
    [fabricante] INTEGER NOT NULL,
    CONSTRAINT [PK_modelos] PRIMARY KEY ([codigo])
)
GO

CREATE TABLE [clientes] (
    [codigo] INTEGER IDENTITY(1,1) NOT NULL,
    [nome] VARCHAR(50) NOT NULL,
    [telefone] VARCHAR(30) NOT NULL,
    [observacoes] VARCHAR(200),
    CONSTRAINT [PK_clientes] PRIMARY KEY ([codigo])
)
GO

ALTER TABLE [veiculos] ADD CONSTRAINT [modelos_veiculos] 
    FOREIGN KEY ([modelo]) REFERENCES [modelos] ([codigo])
GO

ALTER TABLE [veiculos] ADD CONSTRAINT [clientes_veiculos] 
    FOREIGN KEY ([cliente]) REFERENCES [clientes] ([codigo])
GO

ALTER TABLE [modelos] ADD CONSTRAINT [fabricantes_modelos] 
    FOREIGN KEY ([fabricante]) REFERENCES [fabricantes] ([codigo])
GO

