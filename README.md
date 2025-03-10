# Gestor de Produtos

Este é um programa em C# que permite o gerenciamento de produtos, incluindo o cadastro, listagem, registro de entradas e saídas, e a exclusão de produtos. O programa suporta dois tipos de produtos: físicos e online.

## Estrutura do Programa

### Classes e Interfaces

- **IProduto**: Interface que define os métodos que devem ser implementados por produtos.
- **ProdutoFisico**: Classe que representa um produto físico.
- **ProdutoOnline**: Classe que representa um produto online.

### Funcionalidades

1. **Cadastro de Produtos**:
   - O usuário pode cadastrar produtos físicos e online.
   - Os produtos são armazenados em uma lista.

2. **Listagem de Produtos**:
   - O programa exibe todos os produtos cadastrados com seus detalhes.

3. **Registro de Entradas e Saídas**:
   - O usuário pode registrar entradas e saídas de produtos.

4. **Deleção de Produtos**:
   - O usuário pode remover produtos da lista.

5. **Persistência de Dados**:
   - Os produtos são salvos em um arquivo de texto (`produtos.txt`) e podem ser carregados ao iniciar o programa.

## Como Usar

1. **Iniciar o Programa**:
   - O programa começa perguntando se o usuário deseja cadastrar um produto.

2. **Menu de Cadastro**:
   - O usuário pode escolher entre as seguintes opções:
     - 1: Cadastrar Produto Físico
     - 2: Cadastrar Produto Online
     - 3: Listar Produtos
     - 4: Registrar Entradas
     - 5: Registrar Saídas
     - 6: Deletar Produto
     - 7: Sair

3. **Cadastro de Produto Físico**:
   - O usuário deve fornecer o nome, preço e estoque do produto.

4. **Cadastro de Produto Online**:
   - O usuário deve fornecer o nome, preço e autor do produto.

5. **Listar Produtos**:
   - O programa exibe todos os produtos cadastrados.

6. **Registrar Entrada/Saída**:
   - O usuário deve fornecer o ID do produto para registrar a entrada ou saída.

7. **Deletar Produto**:
   - O usuário deve fornecer o ID do produto que deseja remover.


#-------------------------------------------------------------------------------
