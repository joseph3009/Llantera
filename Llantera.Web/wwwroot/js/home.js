
/* ==========================================================================
   LLANTERA WIFRAGARA — home.js
   ========================================================================== */

(function () {
    "use strict";

    /* -----------------------------------------------------------------------
       CONFIGURACIÓN GENERAL
    ----------------------------------------------------------------------- */

    var reduceMotion = window.matchMedia(
        "(prefers-reduced-motion: reduce)"
    ).matches;

    var doc = document.documentElement;

    /* -----------------------------------------------------------------------
       ELEMENTOS PRINCIPALES
    ----------------------------------------------------------------------- */

    var header = document.getElementById("siteHeader");
    var menuToggle = document.getElementById("menuToggle");
    var menuClose = document.getElementById("menuClose");
    var mobileMenu = document.getElementById("mobileMenu");

    var progressBar = document.getElementById("progressBar");
    var sectionIndicator = document.getElementById("sectionIndicator");

    var heroImage = document.getElementById("heroImage");
    var heroTitle = document.getElementById("heroTitle");

    var transitionBg = document.querySelector(".transition-bg");
    var impactImage = document.getElementById("impactImage");
    var aboutImage = document.getElementById("aboutImage");

    /* -----------------------------------------------------------------------
       SERVICIOS
    ----------------------------------------------------------------------- */

    var servicesImage = document.getElementById("servicesImage");

    var serviceItems = Array.prototype.slice.call(
        document.querySelectorAll(".service-item")
    );

    var serviceCurrent = document.getElementById("serviceCurrent");
    var serviceCurrentName = document.getElementById(
        "serviceCurrentName"
    );

    var navLinks = Array.prototype.slice.call(
        document.querySelectorAll(".main-nav a")
    );

    var sections = Array.prototype.slice.call(
        document.querySelectorAll("[data-section-name]")
    );

    var ctaFinal = document.querySelector(".cta-final");


    /* -----------------------------------------------------------------------
       HELPERS
    ----------------------------------------------------------------------- */

    function clamp01(v) {
        return Math.max(0, Math.min(1, v));
    }


    /* -----------------------------------------------------------------------
       HEADER — ESTADO AL HACER SCROLL
    ----------------------------------------------------------------------- */

    var lastScrollState = false;

    function updateHeaderState() {

        if (!header) return;

        var scrolled = window.scrollY > 30;

        if (scrolled !== lastScrollState) {

            header.classList.toggle(
                "is-scrolled",
                scrolled
            );

            lastScrollState = scrolled;
        }
    }


    /* -----------------------------------------------------------------------
       MENÚ MÓVIL
    ----------------------------------------------------------------------- */

    function openMenu() {

        if (!mobileMenu || !menuToggle) return;

        mobileMenu.classList.add("is-open");

        mobileMenu.setAttribute(
            "aria-hidden",
            "false"
        );

        menuToggle.setAttribute(
            "aria-expanded",
            "true"
        );

        doc.style.overflow = "hidden";
    }


    function closeMenu() {

        if (!mobileMenu || !menuToggle) return;

        mobileMenu.classList.remove("is-open");

        mobileMenu.setAttribute(
            "aria-hidden",
            "true"
        );

        menuToggle.setAttribute(
            "aria-expanded",
            "false"
        );

        doc.style.overflow = "";
    }


    if (menuToggle) {

        menuToggle.addEventListener(
            "click",
            function () {

                if (
                    mobileMenu &&
                    mobileMenu.classList.contains("is-open")
                ) {
                    closeMenu();

                } else {

                    openMenu();
                }
            }
        );
    }


    if (menuClose) {

        menuClose.addEventListener(
            "click",
            closeMenu
        );
    }


    Array.prototype.slice.call(
        document.querySelectorAll(
            ".mobile-link, .mobile-cta"
        )
    ).forEach(function (link) {

        link.addEventListener(
            "click",
            closeMenu
        );
    });


    /* -----------------------------------------------------------------------
       INDICADOR DE SECCIÓN
    ----------------------------------------------------------------------- */

    var totalSections = sections.length;
    var currentIndex = 1;


    function setIndicator(i) {

        if (!sectionIndicator) return;

        var num = String(i).padStart(2, "0");

        var total = String(
            totalSections
        ).padStart(2, "0");

        sectionIndicator.innerHTML =
            "<strong>" +
            num +
            "</strong> / " +
            total;
    }


    setIndicator(1);


    if (
        "IntersectionObserver" in window &&
        sections.length
    ) {

        var sectionObserver =
            new IntersectionObserver(

                function (entries) {

                    entries.forEach(
                        function (entry) {

                            if (
                                entry.isIntersecting
                            ) {

                                var idx =
                                    sections.indexOf(
                                        entry.target
                                    ) + 1;

                                currentIndex = idx;

                                setIndicator(idx);

                                var name =
                                    entry.target.getAttribute(
                                        "id"
                                    );

                                navLinks.forEach(
                                    function (link) {

                                        link.classList.toggle(
                                            "is-active",
                                            link.getAttribute(
                                                "data-section"
                                            ) === name
                                        );
                                    }
                                );
                            }
                        }
                    );
                },
                {
                    rootMargin:
                        "-45% 0px -45% 0px",

                    threshold: 0
                }
            );


        sections.forEach(
            function (section) {

                sectionObserver.observe(
                    section
                );
            }
        );
    }


    /* -----------------------------------------------------------------------
       REVEAL — ANIMACIONES AL HACER SCROLL
    ----------------------------------------------------------------------- */

    var revealTargets =
        Array.prototype.slice.call(
            document.querySelectorAll(
                ".reveal, .reveal-clip"
            )
        );


    if (
        "IntersectionObserver" in window &&
        revealTargets.length
    ) {

        var revealObserver =
            new IntersectionObserver(

                function (entries, obs) {

                    entries.forEach(
                        function (entry) {

                            if (
                                entry.isIntersecting
                            ) {

                                entry.target.classList.add(
                                    "is-visible"
                                );

                                obs.unobserve(
                                    entry.target
                                );
                            }
                        }
                    );
                },
                {
                    threshold: 0.15,

                    rootMargin:
                        "0px 0px -5% 0px"
                }
            );


        revealTargets.forEach(
            function (target) {

                revealObserver.observe(
                    target
                );
            }
        );

    } else {

        revealTargets.forEach(
            function (target) {

                target.classList.add(
                    "is-visible"
                );
            }
        );
    }


    /* -----------------------------------------------------------------------
       TESTIMONIOS — STAGGER
    ----------------------------------------------------------------------- */

    Array.prototype.slice.call(
        document.querySelectorAll(
            ".testimonial"
        )
    ).forEach(
        function (card, i) {

            card.classList.add(
                "reveal"
            );

            card.style.transitionDelay =
                i * 0.1 + "s";
        }
    );


    /* -----------------------------------------------------------------------
       CTA FINAL — REVEAL
    ----------------------------------------------------------------------- */

    if (
        ctaFinal &&
        "IntersectionObserver" in window
    ) {

        var ctaObserver =
            new IntersectionObserver(

                function (entries, obs) {

                    entries.forEach(
                        function (entry) {

                            if (
                                entry.isIntersecting
                            ) {

                                ctaFinal.classList.add(
                                    "is-visible"
                                );

                                obs.disconnect();
                            }
                        }
                    );
                },
                {
                    threshold: 0.3
                }
            );


        ctaObserver.observe(
            ctaFinal
        );
    }


    /* -----------------------------------------------------------------------
       HERO — ENTRADA
    ----------------------------------------------------------------------- */

    window.addEventListener(
        "load",
        function () {

            if (!heroTitle) return;

            requestAnimationFrame(
                function () {

                    heroTitle.classList.add(
                        "is-in"
                    );
                }
            );
        }
    );


    /* =======================================================================
       SERVICIOS — PANEL INTERACTIVO
       ======================================================================= */


    /*
       Guardamos el índice del servicio actualmente activo.
    */

    var activeServiceIndex = 0;


    /*
       Actualiza los textos superiores e inferiores del panel.
    */

    function updateServiceInfo(item, index) {

        if (!item) return;


        /* Número del servicio */

        if (serviceCurrent) {

            serviceCurrent.textContent =
                String(index + 1).padStart(2, "0") +
                " / " +
                String(serviceItems.length).padStart(2, "0");
        }


        /* Nombre del servicio */

        if (serviceCurrentName) {

            var nameElement =
                item.querySelector(
                    ".service-name"
                );

            if (nameElement) {

                serviceCurrentName.textContent =
                    nameElement.textContent
                        .trim()
                        .toUpperCase();
            }
        }
    }


    /*
       Cambia la imagen del panel.
    */

    function changeServiceImage(item) {

        if (!servicesImage || !item) {
            return;
        }

        var newImage =
            item.getAttribute(
                "data-image"
            );

        var newAlt =
            item.getAttribute(
                "data-alt"
            ) || "";


        if (!newImage) {
            return;
        }


        /*
           Si es la misma imagen, no hacemos
           una transición innecesaria.
        */

        if (
            servicesImage.getAttribute("src") ===
            newImage
        ) {

            servicesImage.setAttribute(
                "alt",
                newAlt
            );

            return;
        }


        /*
           Fade out.
        */

        servicesImage.classList.remove(
            "is-visible"
        );


        /*
           Esperamos un poco para cambiar
           la imagen y volver a mostrarla.
        */

        window.setTimeout(
            function () {

                servicesImage.setAttribute(
                    "src",
                    newImage
                );

                servicesImage.setAttribute(
                    "alt",
                    newAlt
                );


                /*
                   Forzamos un pequeño reflow
                   para que la transición sea
                   consistente en algunos navegadores.
                */

                void servicesImage.offsetWidth;


                servicesImage.classList.add(
                    "is-visible"
                );

            },
            reduceMotion ? 0 : 180
        );
    }


    /*
       Activa un servicio.
    */

    function setActiveService(
        item,
        index
    ) {

        if (!item) return;


        /*
           Si no recibimos índice,
           lo buscamos.
        */

        if (
            typeof index !== "number"
        ) {

            index =
                serviceItems.indexOf(
                    item
                );
        }


        if (index < 0) {
            index = 0;
        }


        activeServiceIndex =
            index;


        /*
           Quitamos el estado activo
           de todos los servicios.
        */

        serviceItems.forEach(
            function (service) {

                service.classList.toggle(
                    "is-active",
                    service === item
                );
            }
        );


        /*
           Actualizamos información.
        */

        updateServiceInfo(
            item,
            index
        );


        /*
           Cambiamos imagen.
        */

        changeServiceImage(
            item
        );
    }


    /*
       Inicializamos cada servicio.
    */

    serviceItems.forEach(
        function (item, index) {

            /*
               Mouse.
            */

            item.addEventListener(
                "mouseenter",
                function () {

                    setActiveService(
                        item,
                        index
                    );
                }
            );


            /*
               Teclado / accesibilidad.
            */

            item.addEventListener(
                "focus",
                function () {

                    setActiveService(
                        item,
                        index
                    );
                }
            );


            /*
               Click.
               Especialmente importante
               para móviles.
            */

            item.addEventListener(
                "click",
                function () {

                    setActiveService(
                        item,
                        index
                    );
                }
            );


            /*
               Enter / Space.
            */

            item.addEventListener(
                "keydown",
                function (event) {

                    if (
                        event.key === "Enter" ||
                        event.key === " "
                    ) {

                        event.preventDefault();

                        setActiveService(
                            item,
                            index
                        );
                    }
                }
            );


            /*
               Permite navegar con
               flechas cuando el elemento
               tiene foco.
            */

            item.addEventListener(
                "keydown",
                function (event) {

                    var nextIndex;

                    if (
                        event.key === "ArrowDown" ||
                        event.key === "ArrowRight"
                    ) {

                        event.preventDefault();

                        nextIndex =
                            (index + 1) %
                            serviceItems.length;

                        serviceItems[
                            nextIndex
                        ].focus();

                    } else if (
                        event.key === "ArrowUp" ||
                        event.key === "ArrowLeft"
                    ) {

                        event.preventDefault();

                        nextIndex =
                            (index - 1 +
                                serviceItems.length) %
                            serviceItems.length;

                        serviceItems[
                            nextIndex
                        ].focus();
                    }
                }
            );
        }
    );


    /*
       Primer servicio activo.
    */

    if (serviceItems.length) {

        setActiveService(
            serviceItems[0],
            0
        );
    }


    /* -----------------------------------------------------------------------
       SCROLL-LINKED FRAME
    ----------------------------------------------------------------------- */

    var ticking = false;


    function onScrollFrame() {

        ticking = false;


        var scrollY =
            window.scrollY;


        var docHeight =
            doc.scrollHeight -
            window.innerHeight;


        var progress =
            docHeight > 0
                ? clamp01(
                    scrollY / docHeight
                )
                : 0;


        /* ---------------------------------------------------------------
           BARRA DE PROGRESO
        --------------------------------------------------------------- */

        if (progressBar) {

            progressBar.style.width =
                progress * 100 + "%";
        }


        /* ---------------------------------------------------------------
           HERO PARALLAX
        --------------------------------------------------------------- */

        if (heroImage) {

            var heroH =
                window.innerHeight;

            var heroProgress =
                clamp01(
                    scrollY / heroH
                );


            heroImage.style.transform =
                "scale(1.05) translateY(" +
                heroProgress * 50 +
                "px)";
        }


        /* ---------------------------------------------------------------
           TRANSITION PARALLAX
        --------------------------------------------------------------- */

        if (transitionBg) {

            var rect =
                transitionBg.parentElement
                    .getBoundingClientRect();


            var vh =
                window.innerHeight;


            var localProgress =
                clamp01(
                    1 -
                    (rect.top + rect.height) /
                    (vh + rect.height)
                );


            transitionBg.style.transform =
                "translateY(" +
                (localProgress * 35 - 17) +
                "px) scale(1.08)";
        }


        /* ---------------------------------------------------------------
           IMPACT PARALLAX
        --------------------------------------------------------------- */

        if (impactImage) {

            var irect =
                impactImage.getBoundingClientRect();


            var ivh =
                window.innerHeight;


            var iProgress =
                clamp01(
                    1 -
                    (irect.top + irect.height) /
                    (ivh + irect.height)
                );


            impactImage.style.transform =
                "translateY(" +
                (iProgress * 40 - 20) +
                "px) scale(1.04)";
        }


        /*
           Estado del header.
        */

        updateHeaderState();
    }


    function requestTick() {

        if (!ticking) {

            window.requestAnimationFrame(
                onScrollFrame
            );

            ticking = true;
        }
    }


    window.addEventListener(
        "scroll",
        requestTick,
        {
            passive: true
        }
    );


    window.addEventListener(
        "resize",
        requestTick
    );


    onScrollFrame();


    /* -----------------------------------------------------------------------
       NAVEGACIÓN — SCROLL SUAVE
    ----------------------------------------------------------------------- */

    navLinks
        .concat(
            Array.prototype.slice.call(
                document.querySelectorAll(
                    'a[href^="#"]'
                )
            )
        )
        .forEach(
            function (link) {

                link.addEventListener(
                    "click",
                    function (e) {

                        var href =
                            link.getAttribute(
                                "href"
                            );


                        if (
                            href &&
                            href.length > 1 &&
                            href.charAt(0) === "#"
                        ) {

                            var target;

                            try {

                                target =
                                    document.querySelector(
                                        href
                                    );

                            } catch (error) {

                                target = null;
                            }


                            if (target) {

                                e.preventDefault();


                                target.scrollIntoView(
                                    {
                                        behavior:
                                            reduceMotion
                                                ? "auto"
                                                : "smooth",

                                        block: "start"
                                    }
                                );
                            }
                        }
                    }
                );
            }
        );


})();
