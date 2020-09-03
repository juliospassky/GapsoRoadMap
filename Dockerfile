FROM node:13-alpine AS builder

RUN npm install -g @angular/cli@10.0.8
ADD ./package.json /GAPSOROADMAP/package.json
WORKDIR /GAPSOROADMAP/
RUN npm install 
ADD . /GAPSOROADMAP/
RUN ng build

FROM nginx:alpine
COPY --from=builder /GAPSOROADMAP/dist/GapsoRoadMap /usr/share/nginx/html