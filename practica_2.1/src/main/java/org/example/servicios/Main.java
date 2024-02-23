package org.example.servicios;

import io.javalin.Javalin;

public class Main {

    //indica el modo de operacion para la base de datos.


    public static void main(String[] args) {
        Javalin app = Javalin.create(javalinConfig -> {
            javalinConfig.staticFiles.add(staticFileConfig -> {
                staticFileConfig.hostedPath = "/publico";
                staticFileConfig.directory = "/publico" ;
            });
        }).start(7000);
        app.get("/", ctx -> {
            // Redirigir a la ruta "/Blog"
            ctx.redirect("/Blog");
        });
        app.get("/Blog", ctx -> {
            ctx.render("/publico/Blog.html");
        });
        new serviciosArticulos(app).aplicarRutas();
        new serviciosUsuarios(app).aplicarRutas();


    }
}
