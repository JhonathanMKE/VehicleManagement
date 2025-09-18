# Usa a imagem oficial do MySQL
FROM mysql:8.0

# Define variáveis de ambiente para o banco
ENV MYSQL_ROOT_PASSWORD=root
ENV MYSQL_DATABASE=vehicle-management
ENV MYSQL_USER=admin
ENV MYSQL_PASSWORD=1234

# Copia scripts de inicialização (opcional)
# Qualquer .sql ou .sh colocado nessa pasta será executado
## COPY ./initdb /docker-entrypoint-initdb.d/

# Expõe a porta padrão do MySQL
EXPOSE 3306
