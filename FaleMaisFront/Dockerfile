# Baseado em node na última versão
FROM node:latest as node
# Autor
LABEL Douglas Augusto Junior
# Pasta que vai pegar os arquivos e pasta destino
COPY . /FaleMaisFront
# Diretório que ele vai trabalhar, onde vai rodar o start
WORKDIR /FaleMaisFront
# Comando inicial para instalar dependências
RUN npm install
RUN npm run build --omit=dev

# Baseado no nginx
FROM nginx
COPY --from=node /FaleMaisFront/dist/fale-mais-front /usr/share/nginx/html