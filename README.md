# Sistema de Cadastro de Estetica Automotica

Sistema desktop desenvolvido em C# Windows Forms para gerenciamento e cadastro de automoveis e seus donos.

## 📋 Descrição

Este projeto é um sistema de cadastro que permite gerenciar informações sobre cadastro de serviços de automoveis, incluindo nome do dono, seu número e seu carro.Já os automovéis possuem sua placa que referencia o dono, o cpf_do dono,o modelo, categoria,marca e o serviço prestado. O sistema utiliza MySQL como banco de dados e oferece uma interface gráfica intuitiva para cadastro e busca de informações.

## 🚀 Tecnologias Utilizadas

- **C# (.NET Framework)** - Linguagem de programação
- **Windows Forms** - Framework para interface gráfica
- **MySQL 8.1.0** - Sistema de gerenciamento de banco de dados
- **ADO.NET** - Acesso a dados
- **Visual Studio** - IDE de desenvolvimento

## 📦 Dependências

O projeto utiliza as seguintes bibliotecas NuGet:

- MySql.Data 8.1.0


## 🗄️ Estrutura do Banco de Dados

O sistema utiliza duas tabelas principais:

### Tabela 1


CREATE TABLE Dono (
    CPF VARCHAR(14) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Telefone VARCHAR(20)
);

### Tabela 2

CREATE TABLE Carro (
    Placa VARCHAR(10) PRIMARY KEY,
    Marca VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50) NOT NULL,
    Categoria VARCHAR(50),
    Servicos VARCHAR(255),
    CPF_Dono VARCHAR(14),

    FOREIGN KEY (CPF_Dono) REFERENCES Dono(CPF)
       
);


### Stored Procedures

- `sp_alteraCarro` - Altera os dados dos carros
- `sp_alteraDono` - Altera os dados dos Donos 
- `sp_BuscarCarroPorCpfParcial` - Busca os carros que vão ser exibidos no data grid
- `sp_BuscarDonoPorCpfParcial` - Busca os donos que vão ser exibidos no data grid
- `sp_insereCarro`- Faz a inserção de Carros no banco de dados 
- `sp_insereDono`- Faz a inserção de Donos no banco de dados 
- `sp_RemoveCarro`-Faz a remoção dos Carros de banco de dados 
- `sp_RemoveDono`-Faz a remoção dos Donos de banco de dados 

## ⚙️ Instalação e Configuração

### Pré-requisitos

- Visual Studio 2019 ou superior
- MySQL Server 8.0 ou superior
- .NET Framework 4.7.2 ou superior

### Passo a Passo

1. **Clone o repositório**
   ```bash
   git clone <url-do-repositorio>
   cd "Semana 12 - Projeto CSharp - Modelo"
   ```

2. **Configure o Banco de Dados**
   - Abra o MySQL Workbench ou outro cliente MySQL
   - Execute o script `DumpBancoCadastro.sql` para criar as tabelas e procedures
   ```sql
   source DumpBancoCadastro.sql
   ```

3. **Configure a String de Conexão**
   - Abra o arquivo `App.config` no projeto SistemaCadastro
   - Atualize a string de conexão com suas credenciais do MySQL
   ```xml
   <connectionStrings>
     <add name="MySqlConnection" 
          connectionString="Server=localhost;Database=cadastro;Uid=root;Pwd=sua_senha;" 
          providerName="MySql.Data.MySqlClient"/>
   </connectionStrings>
   ```

4. **Restaure os Pacotes NuGet**
   - No Visual Studio, clique com o botão direito na solução
   - Selecione "Restore NuGet Packages"

5. **Compile e Execute**
   - Pressione `F5` ou clique em "Start" no Visual Studio

## 🎯 Funcionalidades

- ✅ **Cadastro de Carros e Donos** - Adicione os donos e seus carros para organizar seus clientes com informações completas
- 🔍 **Busca de Carros e Donos** - Pesquise seus clientes
- 📝 **Alteração de Dados** - Edite informações de Donos e Carros existentes
- 🗑️ **Remoção de Carros e Donos** - Exclua registros do sistema
-    **Gerenciamento de Carros** - Adicione novos Carros e Donos ja existentes
- 📊 **Visualização em Lista** - Veja todos carros ou donos cadastrados

## 📁 Estrutura do Projeto

```
SistemaCadastro/
├── Program.cs              # Ponto de entrada da aplicação
├── Sistema.cs              # Lógica principal do formulário
├── Sistema.Designer.cs     # Designer do Windows Forms
├── App.config             # Configurações da aplicação
├── packages.config        # Configuração de pacotes NuGet
└── Properties/            # Propriedades do projeto
    ├── AssemblyInfo.cs
    ├── Resources.resx
    └── Settings.settings
```

## 🎨 Interface

O sistema possui uma interface com navegação por abas:

- **Aba Cadastro** - Formulário para inserir novos carros e donos
- **Aba Busca** - Interface para pesquisar e visualizar carros e bandas cadastradas

A navegação é facilitada por botões laterais com indicador visual de aba selecionada.


## 📝 Licença

Este projeto é um trabalho acadêmico desenvolvido para fins educacionais.

## 👥 Autor

Desenvolvido como projeto do curso de Linguagem I

Luan Vitor Santos de Paula

**Nota**: Este é um projeto modelo para fins educacionais. Certifique-se de implementar as validações e tratamento de erros adequados antes de usar em produção.
