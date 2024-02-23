package org.example.servicios;

import io.javalin.Javalin;
import io.javalin.rendering.JavalinRenderer;
import io.javalin.rendering.template.JavalinThymeleaf;
import org.example.entidades.Articulo;
import org.example.entidades.Usuario;

import java.util.HashMap;
import java.util.Map;

public class servicioCrearArticulo  extends BaseControlador{
    public servicioCrearArticulo(Javalin app) {
        super(app);
        buscarTemplates();
    }
    public void buscarTemplates(){
        JavalinRenderer.register(new JavalinThymeleaf(),".html");
    }

    @Override
    public void aplicarRutas() {
        Javalin javalin = app.before("/login", ctx -> {

        });
        app.post("/Blog", ctx -> {
            String titulo = ctx.formParam("usuario");
            String contendido = ctx.formParam("password");


        });

        app.get("/Blog", ctx -> {
            // Verificar si el usuario está autenticado antes de renderizar la página del blog
            Usuario usuario = ctx.sessionAttribute("usuario");
            if (usuario != null) {
                ctx.render("/publico/Blog.html");
            } else {
                // Si el usuario no está autenticado, redirigir al formulario de inicio de sesión
                ctx.redirect("/login");
            }
        });

    }
}
